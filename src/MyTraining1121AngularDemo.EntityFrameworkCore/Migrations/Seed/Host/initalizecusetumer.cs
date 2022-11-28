using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using MyTraining1121AngularDemo.Authorization.Roles;
using MyTraining1121AngularDemo.Authorization.Users;
using MyTraining1121AngularDemo.CustomerBook;
using MyTraining1121AngularDemo.EntityFrameworkCore;
using MyTraining1121AngularDemo.PhoneBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Migrations.Seed.Host
{
    public class Initalizecusetumer
    {
        private readonly MyTraining1121AngularDemoDbContext _context;
        private readonly IRepository<User, long> _userreop;
        List<long> _usersid;

        public Initalizecusetumer(MyTraining1121AngularDemoDbContext context, IRepository<User, long> userreop)
        {
            _context = context;
            _userreop = userreop;

          
        }


        public async Task createuserAsync()
        {
            for (int i = 0; i <= 100; i++)
            {
                var name = Faker.Name.First();
                var user = new User
                {
                    Name= name,
                    Surname=Faker.Name.Middle(),
                    EmailAddress=Faker.Internet.Email(name),
                    PhoneNumber=Faker.Phone.Number(),   
                    UserName=Faker.Name.First(),
                    Password="Abhi@123"
                   
                   
                };
                var userid = await _userreop.InsertAndGetIdAsync(user);
                _usersid.Add(userid);

                var userddds = _context.Users.SingleOrDefaultAsync(x => x.Id == userid);

                var roledi = _context.Roles.SingleOrDefaultAsync(x=>x.Name== StaticRoleNames.Host.Admin).Id;

                _context.UserRoles.Add(new UserRole(null, userddds.Id, roledi));
                _context.SaveChanges();

            }   


        }
        public void Create()
        {
            for (int i = 0; i <= 100; i++)
            {
                var name = Faker.Name.First();
                var Email = Faker.Internet.Email(name);
                var douglas = _context.Persons.FirstOrDefault(p => p.EmailAddress == Email);
                if (douglas == null)
                {
                    _context.Customer.Add(
                        new Customer
                        {
                            Name = name +" "+Faker.Name.Middle()+" "+Faker.Name.Last(),
                            Address = Faker.Address.SecondaryAddress(),
                            EmailAddress = Email,
                            custUser = new List<CustomerUsers>
                                    {
                                    new CustomerUsers { UserId = 1},
                                    new CustomerUsers { UserId = 1}
                                    }
                        });
                }

            }
        }



    }
}
