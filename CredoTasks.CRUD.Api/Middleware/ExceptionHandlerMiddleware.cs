﻿using CredoTasks.CRUD.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CredoTasks.CRUD.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }
        private Task ConvertException(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var result = string.Empty;
            switch (exception)
            {
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.ValidationErrors);
                    break;
                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case Exception ex:
                    httpStatusCode = HttpStatusCode.InternalServerError;
                    break;
            }
            context.Response.StatusCode = (int)httpStatusCode;

            if(result == string.Empty)
            {
                result = JsonConvert.SerializeObject(new { error = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
