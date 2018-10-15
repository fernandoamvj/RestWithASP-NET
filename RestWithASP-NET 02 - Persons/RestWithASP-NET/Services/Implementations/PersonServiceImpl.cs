using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private MySqlContext _context;

        public PersonServiceImpl(MySqlContext context)
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            try {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            try
            {
                var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
                _context.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            try
            {
                _context.Update(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }
    }
}
