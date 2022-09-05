using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase
{
    private IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet()]
    public IDataResult<List<UserVm>> GetUsers()
    {
        IDataResult<List<User>> getUsers = _userService.GetAll();
        List<UserVm> userListVms = new List<UserVm>();
        foreach (var user in getUsers.Data)
        {
         
            UserVm vm = new UserVm()
            {
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname
            };   
            userListVms.Add(vm);
        }
        return new SuccessDataResult<List<UserVm>>(userListVms,getUsers.Message);
    }
    [HttpGet("getById")]
    public IDataResult<UserVm> GetUserById(int id)
    {
        var getUser = _userService.GetById(user => user.Id == id);
        
        UserVm vm = new UserVm()
        {
            Email = getUser.Data.Email,
            Name = getUser.Data.Name,
            Surname = getUser.Data.Surname
        };   
        return new SuccessDataResult<UserVm>(vm,getUser.Message);
    }

    [HttpPost]
    public IResult Add(AddUserVm addUserVm)
    {
        
        User user = new()
        {
            Email = addUserVm.Email,
            Name = addUserVm.Name,
            Surname = addUserVm.Surname,
            Password = "uservm",
        };
        var result = _userService.Add(user);
        return new Result(result.Success,result.Message);
    }
}