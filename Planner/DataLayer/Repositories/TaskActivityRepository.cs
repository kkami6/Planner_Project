using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using BuisnessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class TaskActivityRepository: PlannerContext
    {
        private readonly PlannerContext _context;
        
        public TaskActivityRepository(PlannerContext context)
        {
            _context = context;
        }

        public async Task<TaskActivity> Create(TaskActivity model)
        {
            var entity = model.ToEntity();
            await _context.TaskActivities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TaskActivity> Read(int id)
        {
            var entity = await _context.TaskActivities.SingleOrDefaultAsync(t => t.ActivityId == id);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TaskActivity> ReadAll()
        {
            var entities = await _context.TaskActivities.ToListAsync();
            return entities;
        }

        public async Task<TaskActivity> Update(TaskActivity model)
        {
            var entity = await _context.TaskActivities.SingleAsync(t => t.ActivityId == model.ActivityId);
            var updated = model.ToEntity();

            entity.Name = updated.Name;
            entity.UserId = updated.UserId;
            entity.Date = updated.Date;
            entity.Description = updated.Description;
            entity.Color = updated.Color;
            entity.Recurrence = updated.Recurrence;
            entity.DueDate = updated.DueDate;
            entity.IsCompleted = updated.IsCompleted;

            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TaskActivity> Delete(int id)
        {
            var entity = await _context.TaskActivities.SingleOrDefaultAsync(t => t.ActivityId == id);
            _context.TaskActivities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
