using App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    
    public class ArtistDA
    {
        private ChinookModel _context;
        public ArtistDA()
        {
            _context = new ChinookModel();
        }
        public int Count()
        {
            //Select count(*) from Artist
            return _context.Artist.Count();
        }

        public List<Artist> Gets(string filtroByNombre)
        {
            //Aerosmith
            //aero
            //Select * from Artist where Name like '%aero%'
            /*
             Contains: ejemplo= like '%aero%' 
            StartsWith:ejemplo= like 'aero%' 
            EndsWith:ejemplo= like '%aero' 
            == ejemplo: = '%aero%' 
            && = AND
            || =  OR
            */
            return _context.Artist
                .Where(item=>item.Name.Contains(filtroByNombre)               
                )
                .ToList();
        }

        public int Insert(Artist entity)
        {
            //Se el objeto al contexto de entity framework
            _context.Artist.Add(entity);

            //Confirman la persistencia en base de datos
            _context.SaveChanges();

            return entity.ArtistId;
        }

        public bool Update(Artist entity)
        {
            //Se adiciona el objeto al contexto de entity framework
            _context.Artist.Attach(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
           // _context.Entry(entity).Property(item => item.Name).IsModified = false;

            //Confirman la persistencia en base de datos
            var result = _context.SaveChanges();

            return result>0;
        }

        public bool Delete(Artist entity)
        {
            //Se adiciona el objeto al contexto de entity framework
            _context.Artist.Attach(entity);
            _context.Artist.Remove(entity);

            //Confirman la persistencia en base de datos
            var result = _context.SaveChanges();

            return result>0;
        }
    }
}
