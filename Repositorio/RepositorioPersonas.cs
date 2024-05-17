﻿using Catalogo.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Repositorio
{
    public class RepositorioPersonas : IRepositorioPersonas
    {
        private readonly CatalogoDBContext _context;

        public RepositorioPersonas(CatalogoDBContext context)
        {
            _context = context;
        }
        public async Task<Persona> Add(Persona persona)
        {
            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();
            return persona;
        }
        
        public async Task Delete(int id) 
        { 
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Persona?> Get(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task<List<Persona>> GetAll()
        {
            return await _context.Personas.Include(c => c.Clasificacion).ToListAsync();
        }

        public async Task Update(int  id, Persona persona)
        {
            var personaactual = await _context.Personas.FindAsync(id);
            if (personaactual != null)
            {
                personaactual.Name = persona.Name;
                personaactual.Email = persona.Email;
                personaactual.Telefono = persona.Telefono;
                await _context.SaveChangesAsync();
            }
        }
    }
}
