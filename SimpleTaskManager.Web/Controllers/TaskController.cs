﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleTaskManager.Data.Dtos;
using SimpleTaskManager.Data.Entities;
using SimpleTaskManager.Data.Repositories;
using SimpleTaskManager.Web.Common;

namespace SimpleTaskManager.Web.Controllers
{
 
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepo;

        public TaskController(ITaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Simple Task Manager - Tasks";                        
            return View(await _taskRepo.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Title = "Simple Task Manager - Add";
            ViewBag.priorityDdl = typeof(TaskPriority).ToSelectList().OrderByDescending(x => x.Value).ToList();
            ViewBag.statusDdl = typeof(Data.Entities.TaskStatus).ToSelectList();
            return View(new TaskDto());
        }

        [HttpPost]
        public async Task<IActionResult> Add(TaskDto dto)
        {
            if (!ModelState.IsValid)
                return await Add();
            ViewBag.Title = "Simple Task Manager - Add";
            
            await _taskRepo.AddAsync(dto);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(_taskRepo.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskDto dto)
        {
            if (!ModelState.IsValid)
                return await Add();
            ViewBag.Title = "Simple Task Manager - Add";

            await _taskRepo.EditAsync(dto);
            return RedirectToAction("Index");
        }


    }
}