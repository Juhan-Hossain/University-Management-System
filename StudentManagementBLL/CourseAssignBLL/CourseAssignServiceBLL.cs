using RepositoryLayer;
using StudentManagementDAL;
using StudentManagementEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementBLL.CourseAssignBLL
{
    public class CourseAssignServiceBLL : Repository<CourseAssignment, ApplicationDbContext>, ICourseAssignServiceBLL
    {
        private readonly ApplicationDbContext Context;

        public CourseAssignServiceBLL(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.Context = dbContext;
        }
        //validates the fact of course assignment
        public virtual ServiceResponse<CourseAssignment> AssignCourseToTeacher(int departmentId, string CourseCode, int teacherId)
        {
            var serviceResponse = new ServiceResponse<CourseAssignment>();
            try
            {
                Course fetchingCourse = Context.Courses.SingleOrDefault(x => x.Code == CourseCode);
                Teacher fetchingTeacher = Context.Teachers.SingleOrDefault(x => x.Id == teacherId);
                Department fetchingDepartment = Context.Departments.SingleOrDefault(x => x.Id == departmentId);
                serviceResponse.Data = Context.CourseAssignments.SingleOrDefault(x =>
                x.DepartmentId == fetchingDepartment.Id
                /*&& x.TeacherId == fetchingTeacher.Id*/
                 && x.Code == fetchingCourse.Code);


                if (fetchingCourse is null)
                {
                    serviceResponse.Message = "this Course does not exist.";
                    serviceResponse.Success = false;
                }
                else if (fetchingTeacher is null)
                {
                    serviceResponse.Message = "this Teacher does not exist.";
                    serviceResponse.Success = false;
                }
                else if (fetchingDepartment is null)
                {
                    serviceResponse.Message = "this Department does not exist.";
                    serviceResponse.Success = false;
                }
                else if (serviceResponse.Data == null && serviceResponse.Success)
                {
                    /*if (!serviceResponse.Success)
                    {
                        serviceResponse.Message = "Course is already assigned.";
                        serviceResponse.Success = false;
                    }
                    else
                    {*/

                    CourseAssignment aCourseAssignment = new CourseAssignment();

                    if (fetchingTeacher.RemainingCredit >= fetchingCourse.Credit)
                    {
                        try
                        {
                            fetchingTeacher.RemainingCredit -= fetchingCourse.Credit;/*
                                fetchingTeacher.CreditToBeTaken -= fetchingCourse.Credit;*/

                            fetchingCourse.AssignTo = fetchingTeacher.Name;
                            fetchingCourse.TeacherId = fetchingTeacher.Id;

                            aCourseAssignment.TeacherId = teacherId;
                            aCourseAssignment.DepartmentId = departmentId;
                            aCourseAssignment.CourseId = fetchingCourse.Id;
                            aCourseAssignment.IsAssigned = 2;
                            aCourseAssignment.Code = CourseCode;


                            Context.CourseAssignments.Add(aCourseAssignment);

                            serviceResponse.Data = aCourseAssignment;/*
                                serviceResponse.Success = true;*/

                            serviceResponse.Message = $"{fetchingTeacher.Name} will start taking {fetchingCourse.Code}" +
                               $": {fetchingCourse.Name}";
                        }
                        catch (Exception ex)
                        {
                            serviceResponse.Message = "error occured while assigning a course to a teacher \n" +
                                ex.Message;
                            serviceResponse.Success = false;
                        }

                    }
                    else
                    {

                        fetchingTeacher.RemainingCredit = 0;
                        fetchingTeacher.CreditToBeTaken += fetchingCourse.Credit;

                        fetchingCourse.AssignTo = fetchingTeacher.Name;
                        fetchingCourse.TeacherId = fetchingTeacher.Id;

                        aCourseAssignment.TeacherId = teacherId;
                        aCourseAssignment.DepartmentId = departmentId;
                        aCourseAssignment.CourseId = fetchingCourse.Id;
                        aCourseAssignment.IsAssigned = 2;
                        aCourseAssignment.Code = CourseCode;


                        Context.CourseAssignments.Add(aCourseAssignment);

                        serviceResponse.Data = aCourseAssignment;/*
                                serviceResponse.Success = true;*/

                        serviceResponse.Message = $"{fetchingTeacher.Name} will start taking {fetchingCourse.Code}" +
                           $": {fetchingCourse.Name}";
                        /*serviceResponse.Message = $"{fetchingTeacher.Name} does not have Remaining" +
                            $" Credit to take {fetchingCourse.Code}: {fetchingCourse.Name}";
                        serviceResponse.Success = false;*/
                    }
                    //}

                }
                else if (serviceResponse.Data.IsAssigned == 1)
                {
                    try
                    {
                        serviceResponse.Data.IsAssigned = 2;
                        serviceResponse.Data.DepartmentId = departmentId;
                        serviceResponse.Data.CourseId = fetchingCourse.Id;

                        serviceResponse.Data.Code = CourseCode;

                        Context.CourseAssignments.Update(serviceResponse.Data);
                    }
                    catch (Exception error)
                    {
                        serviceResponse.Message = "error occured while updating assigning course\n" +
                            error.Message;

                    }

                }
                else
                {
                    serviceResponse.Message = "Course is already assigned!!";
                    serviceResponse.Success = false;
                }
                Context.SaveChanges();
            }
            catch (Exception exception)
            {
                serviceResponse.Message = "This course already assigned a teacher.";
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

    }
}