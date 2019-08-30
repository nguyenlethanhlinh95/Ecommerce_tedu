﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KetNoiCSDL.EF;

namespace KetNoiCSDL.DAO
{
    public class UserDao
    {
        BanhangOnlineDbContext db = null;
        public UserDao()
        {
            db = new BanhangOnlineDbContext();
        }
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        {
            return db.Users.SingleOrDefault(x => x.UserName == UserName);
        }
        {
            var res = db.Users.SingleOrDefault(x => x.UserName == UserName);
            if (res == null)
            {
                return 0;
            }
            else
            {
                if (res.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (res.Password == PassWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
        {
            //return db.Users.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public User user(int id)
        {
            return db.Users.Find(id);
        }
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Name = entity.Name;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        {
            return db.Users.Find(id);
        }
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}