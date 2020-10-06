using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.EntityClient;


namespace FinancialAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UsersContext db;
        public UsersController(UsersContext context)
        {
            db = context;            
        }
        // GET: api/<OperationsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await db.Users.ToListAsync();
        }

        // GET api/<OperationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        // GET api/<OperationsController>/2020-10-06
        [HttpGet("{dayreport}/{date}")]
        public async Task<ActionResult<IEnumerable<int>>> Get(string date)
        {
            int sumIncome = 0;
            int sumExpence = 0;
            List<User> listUsers = await db.Users.Where(x => x.Date == date).ToListAsync();
            List<int> resultList = new List<int>();
            foreach (User tmp in listUsers)
            {
                if (tmp.Operation.Equals("1"))
                {
                    sumIncome += Convert.ToInt32(tmp.Sum);
                }
                if (tmp.Operation.Equals("0"))
                {
                    sumExpence += Convert.ToInt32(tmp.Sum);
                }
            }
            resultList.Add(sumExpence);
            resultList.Add(sumIncome);            
            return resultList;
        }

        [HttpGet("{monthreport}/{year}/{month}")]
        public async Task<ActionResult<IEnumerable<int>>> Get(string year, string month)
        {
            int sumIncome = 0;
            int sumExpence = 0;
            List<User> listUsers = await db.Users.
                Where(x => System.Data.Entity.SqlServer.SqlFunctions.DatePart("YEAR", x.Date).Value == 1))
            List<int> resultList = new List<int>();
            foreach (User tmp in listUsers)
            {
                if (tmp.Operation.Equals("1"))
                {
                    sumIncome += Convert.ToInt32(tmp.Sum);
                }
                if (tmp.Operation.Equals("0"))
                {
                    sumExpence += Convert.ToInt32(tmp.Sum);
                }
            }
            resultList.Add(sumExpence);
            resultList.Add(sumIncome);
            return resultList;
        }


        // POST api/users
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        // PUT api/<OperationsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            db.Update(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }

        // DELETE api/<OperationsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
