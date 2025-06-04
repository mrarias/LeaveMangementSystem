using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveMangementSystem.Web.Data;
using LeaveMangementSystem.Web.Models.LeaveTypes;
using AutoMapper;
using LeaveMangementSystem.Web.Services;

namespace LeaveMangementSystem.Web.Controllers
{
    //this is primary constructor
    public class LeaveTypesController(ILeaveTypesService _leaveTypesService) : Controller
    {
        //private readonly ApplicationDbContext _context;
        //private readonly IMapper _mapper;
        private const string NameExistsValidationMessage = "This leave type already exists in the database";
        //private readonly ILeaveTypesService _leaveTypesService = leaveTypesService;

        //public LeaveTypesController(ApplicationDbContext context, IMapper mapper)
        //{
        //    _context = context;
        //    this._mapper = mapper;
        //}

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            //var data = await _context.LeaveTypes.ToListAsync();
            //// convert the datamodel into a view model - Use AutoMapper
            //var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
            
            //this is a sample dependency injection where the above script is abtracted or 
            //or encapsulate a functionality behind a class that makes the controllers thinner
            var viewData = await _leaveTypesService.GetAll();
            //var viewData = data.Select(q => new IndexVM
            //{
            //    Id = q.Id,
            //    Name = q.Name,
            //    NumberOfDays = q.NumberOfDays,
            //});
            // return the view model to the view
            return View(viewData);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Parameterization - key for preventing SQL Injection attacks
            //var leaveType = await _context.LeaveTypes
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //below is the implementation of a generic method
            var leaveType = await _leaveTypesService.Get<LeaveTypeReadOnlyVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }

            //var viewData = _mapper.Map<LeaveTypeReadOnlyVM>(leaveType);
            return View(leaveType);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreate)
        {
            // Adding custom validation and model state error
            if (await _leaveTypesService.CheckIfLeaveTypeNameExists(leaveTypeCreate.Name))
            {
                ModelState.AddModelError(nameof(leaveTypeCreate.Name), NameExistsValidationMessage);
            }
            //if (leaveTypeCreate.Name.Contains("vacation"))
            //{
            //    ModelState.AddModelError(nameof(leaveTypeCreate.Name), "Name should not contain vacation");
            //}

            if (ModelState.IsValid)
            {
                //var leaveType = _mapper.Map<LeaveType>(leaveTypeCreate);
                //_context.Add(leaveType);
                //await _context.SaveChangesAsync();
                await _leaveTypesService.Create(leaveTypeCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeCreate);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _leaveTypesService.Get<LeaveTypeEditVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeEditVM leaveTypeEdit)
        {
            if (id != leaveTypeEdit.Id)
            {
                return NotFound();
            }

            // Adding custom validation and model state error
            if (await _leaveTypesService.CheckIfLeaveTypeNameExistsForEdit(leaveTypeEdit))
            {
                ModelState.AddModelError(nameof(leaveTypeEdit.Name), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //var leaveType = _mapper.Map<LeaveType>(leaveTypeEdit);
                    //_context.Update(leaveType);
                    //await _context.SaveChangesAsync();
                    await _leaveTypesService.Edit(leaveTypeEdit);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_leaveTypesService.LeaveTypeExists(leaveTypeEdit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeEdit);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var leaveType = await _context.LeaveTypes
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var leaveType = await _leaveTypesService.Get<LeaveTypeReadOnlyVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var leaveType = await _context.LeaveTypes.FindAsync(id);
            //if (leaveType != null)
            //{
            //    _context.LeaveTypes.Remove(leaveType);
            //}

            //await _context.SaveChangesAsync();
            await _leaveTypesService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
