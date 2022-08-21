using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly StevenEntities db = new StevenEntities();
        // GET api/values
        // 取出所有使用者清單
        public IHttpActionResult GetAllUser()
        {
            List<Users> userList = db.Users.ToList();
            return Ok(userList);
        }

        // GET api/values/5
        // 取得使用者資料
        public IHttpActionResult GetUser(int id)
        {
            Users targetUser = db.Users.Find(id);
            return Ok(targetUser);
        }

        // POST api/values
        // 新增使用者資料
        public void AddUser([FromBody] Users user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        // PUT api/values/5
        public void UpdateUser(int id, [FromBody] Users value)
        {
            Users targetUser = db.Users.Find(id);
            targetUser.Name = value.Name;
            targetUser.Age = value.Age;
            targetUser.Email = value.Email;
            // 此方法也可行 但得確保id存在
            // db.Entry(value).State = EntityState.Modified;
            db.SaveChanges();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Users targetUser = db.Users.Find(id);
            db.Users.Remove(targetUser);
            db.SaveChanges();
        }
    }
}
