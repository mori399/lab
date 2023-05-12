﻿using Microsoft.EntityFrameworkCore;

namespace Todo.Backend.Persistence;

public class TodoDbContext : DbContext
{
    public DbSet<Models.Todo> Todos { get; set; }

    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
    }
}