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
                && x.TeacherId == fetchingTeacher.Id
                 && x.Code != fetchingCourse.Code);

<<<<<<< HEAD
            Course fetchingCourse = Context.Courses.SingleOrDefault(x => x.Code == CourseCode);
            Teacher fetchingTeacher = Context.Teachers.SingleOrDefault(x => x.Id == teacherId);
            Department fetchingDepartment = Context.Departments.SingleOrDefault(x => x.Id == departmentId);
            serviceResponse.Data = Context.CourseAssignments.SingleOrDefault(x =>
            x.DepartmentId == fetchingDepartment.Id
            && x.TeacherId == fetchingTeacher.Id
             && x.Code != fetchingCourse.Code);
            
            if (fetchingCourse is null)
            {
                serviceResponse.Message = "this Course does not exist.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            if (fetchingTeacher is null)
            {
                serviceResponse.Message = "this Teacher does not exist.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            if (fetchingDepartment is null)
            {
                serviceResponse.Message = "this Department does not exist.";
                serviceResponse.Success = false;
                return serviceResponse;
            }
            if (serviceResponse.Data == null)
            {
                CourseAssignment aCourseAssignment = new CourseAssignment();
               
                if (fetchingTeacher.RemainingCredit - fetchingCourse.Credit >= 0 && fetchingCourse.TeacherId == null)
=======

                if (fetchingCourse is null)
>>>>>>> a277d2137235d34bffb92c2c5d04081b4e51e600
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
                else if (serviceResponse.Data == null)
                {
                    if (!serviceResponse.Success)
                    {
                        serviceResponse.Message = "Course is already assigned.";
                        serviceResponse.Success = false;
                    }
                    else
                    {

<<<<<<< HEAD
                        aCourseAssignment.TeacherId = fetchingTeacher.Id;
                        aCourseAssignment.DepartmentId = fetchingDepartment.Id;
                        aCourseAssignment.CourseId = fetchingCourse.Id;
                        aCourseAssignment.IsAssigned = 2;
                        aCourseAssignment.Code = fetchingCourse.Code;
                        var p = Context.CourseAssignments
                            .Any(x => x.Code == fetchingCourse.Code && x.IsAssigned == 2);
                        if (!p)
=======
                        CourseAssignment aCourseAssignment = new CourseAssignment();
                        
                        if (fetchingTeacher.RemainingCredit >= fetchingCourse.Credit  || fetchingTeacher.RemainingCredit==null )
>>>>>>> a277d2137235d34bffb92c2c5d04081b4e51e600
                        {
                            try
                            {
                                fetchingTeacher.RemainingCredit  -= fetchingCourse.Credit;/*
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
<<<<<<< HEAD

                            serviceResponse.Message = "course already assigned to a teacher";
=======
                            serviceResponse.Message = $"{fetchingTeacher.Name} does not have Remaining" +
                            $" Credit to take {fetchingCourse.Code}: {fetchingCourse.Name}";
>>>>>>> a277d2137235d34bffb92c2c5d04081b4e51e600
                            serviceResponse.Success = false;
                        }
                    }

                }
<<<<<<< HEAD

                /*//need to be redirect this call
                serviceResponse.Message = $"{fetchingTeacher.Name} does not have Remaining" +
                $" Credit to take {fetchingCourse.Code}: {fetchingCourse.Name}";
                serviceResponse.Success = false;
                _dbContext.SaveChanges();
                return serviceResponse;*/
            }



            else
            {
                serviceResponse.Message = "error occured while adding to course assign table";
=======
                else if (serviceResponse.Data.IsAssigned == 1 || serviceResponse.Data.IsAssigned == 3)
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
                        throw;
                    }
                    
                }
                else
                {
                    serviceResponse.Message = "Course is not assigned or need to be updated";
                    serviceResponse.Success = false;
                }
                Context.SaveChanges();
            }
            catch (Exception exception)
            {
                serviceResponse.Message = "Some error occurred while fetching data.\nError message: " + exception.Message;
>>>>>>> a277d2137235d34bffb92c2c5d04081b4e51e600
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }
}