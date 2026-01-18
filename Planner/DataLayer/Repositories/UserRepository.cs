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
    public class UserRepository: PlannerContext
    {
        private readonly PlannerContext _context;

        public UserRepository(PlannerContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User model)
        {
            var entity = model.ToEntity();
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<User> Read(int id)
        {
            var entity = await _context.Users.SingleOrDefaultAsync(u => u.id == id);
            return entity;
        }

        public async Task<List<User>> ReadAll()
        {
            var entities = await _context.Users.ToListAsync();
            return entities;
        }

        public async Task<User> Update(User model)
        {
            var entity = await _context.Users.SingleAsync(u => u.id == model.Id);
            var updated = model.ToEntity();

            entity.UserName = updated.UserName;
            entity.Email = updated.Email;
            entity.FirstName = updated.FirstName;
            entity.LastName = updated.LastName;

            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<User> Delete(int id)
        {
            var entity = await _context.Users.SingleOrDefaultAsync(u => u.id == id);
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
