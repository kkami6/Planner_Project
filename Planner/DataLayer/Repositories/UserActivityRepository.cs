using BuisnessLayer.Models;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UserActivityRepository: PlannerContext
    {
        private readonly PlannerContext _context;

        public UserActivityRepository(PlannerContext context)
        {
            _context = context;
        }

        public async Task<UserActivity> Create(UserActivity model)
        {
            var entity = model.ToEntity();
            await _context.UserActivities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<UserActivity> Read(int id)
        {
            var entity = await _context.UserActivities.SingleOrDefaultAsync(u => u.id == id);
            return entity;
        }

        public async Task<List<UserActivity>> ReadAll()
        {
            var entities = await _context.UserActivities.ToListAsync();
            return entities;
        }

        public async Task<UserActivity> Update(UserActivity model)
        {
            var entity = await _context.UserActivities.Single(u => u.id == model.ActivityId);
            var updated = Model.ToEntity();

            entity.Name = updated.Name;
            entity.UserId = updated.UserId;
            entity.Date = updated.Date;
            entity.Description = updated.Description;
            entity.Color = updated.Color;
            entity.Recurrance = updated.Recurrance;

            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<UserActivity> Delete(int id)
        {
            var entity = await _context.UserActivities.SingleOrDefaultAsync(u => u.id == id);
            _context.UserActivities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
