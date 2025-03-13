global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using System.Transactions;
global using System.ComponentModel.DataAnnotations;
global using BCrypt.Net;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using System.Text;
global using System.Security.Claims;
global using System.IdentityModel.Tokens.Jwt;
global using Microsoft.AspNetCore.Authorization;
global using System.Runtime.InteropServices;
global using Controllers;
global using Microsoft.OpenApi.Models;
global using Swashbuckle.AspNetCore.Annotations;



//Files
global using ExpenseApi.Categories;
global using ExpenseApi.Transaction;
global using ExpenseApi.Users;
global using ExpenseApi.Enums;
global using ExpenseApi.DTO.UserDtos.Authorize;
global using ExpenseApi.DTO.UserDtos.Response;
global using ExpenseApi.DTO.CategoryDtos.Request;
global using ExpenseApi.DTO.CategoryDtos.Response;
global using ExpenseApi.DTO.TransactionDtos.Request;
global using ExpenseApi.DTO.TransactionDtos.Response;
global using Configuration;
global using ExpenseApi.Context;
global using ExpenseApi.Interface.Repositories;
global using Responses;
global using ExpenseApi.Repositories;
global using ExpenseApi.Interface.Service;
global using Service;
global using ExpenseApi.Interface.Services;