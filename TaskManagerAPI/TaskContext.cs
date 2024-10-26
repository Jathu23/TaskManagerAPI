using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerAPI
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<user> Users { get; set; }
    }
}
