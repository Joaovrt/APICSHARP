﻿using APICSHARP.Application.ViewModel;
using APICSHARP.Domain.DTOs;
using APICSHARP.Domain.Model.EmployeeAggregate;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APICSHARP.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/employee")]
    [ApiVersion("1.0")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] EmployeeViewModel employeeView)
        {
            var filePath = Path.Combine("Storage", employeeView.Photo.FileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeView.Photo.CopyTo(fileStream);
            var employee = new Employee(employeeView.Name, employeeView.Age, filePath);
            _employeeRepository.Add(employee);
            return Ok();
        }


        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            var employees = _employeeRepository.GetAll(pageNumber, pageQuantity);
            _logger.LogInformation("Teste");
            return Ok(employees);
        }

        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);
            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);
            return File(dataBytes, "image/png");
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Search(int id)
        {
            var employess = _employeeRepository.Get(id);

            var employeesDTOS = _mapper.Map<EmployeeDTO>(employess);

            return Ok(employeesDTOS);
        }
    }
}
