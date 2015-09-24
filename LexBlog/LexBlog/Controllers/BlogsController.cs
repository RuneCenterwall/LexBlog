﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LexBlog.Models;
using Microsoft.AspNet.Identity;

namespace LexBlog.Controllers
{
    public class BlogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blogs
        public ActionResult Index(string userName)
        {
            List<Blog> blogList;
            if (string.IsNullOrEmpty(userName))
            {
                blogList = db.Blogs.ToList();
            }
            else
            {
                blogList = db.Blogs.Where(b => b.Owner.UserName == userName).ToList();
            }

            return View(blogList);
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description")] Blog blog)
        {



            if (ModelState.IsValid)
            {



                blog.Created = DateTime.Now;
                blog.Edited = DateTime.Now;
                blog.Views = 0;
                blog.Owner = db.Users.First(usr => usr.UserName == User.Identity.Name);
                db.Blogs.Add(blog);
                db.SaveChanges();

                return RedirectToAction("BlogView");
            }

            return View(blog);
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Created,Title,Body,Views")] Blog blog)
        {


            if (ModelState.IsValid)
            {
                blog.Edited = DateTime.Now;
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        // GET: BlogListByViews
        //public ActionResult BlogListByViews()
        //{
        //    List<BlogListByViewsViewModel> blogList;

        //    blogList = db.Blogs.ToList();

        //    return View(blogList);
        //}


        public ActionResult MyBlog()
        {
            return View();
        }

        public ActionResult BlogView()
        {
            return View();
        }

        public ActionResult SearchResult(String searchtext)
        {



            return RedirectToAction("AllResult", new { message = "Search Result" });
        }

        public ActionResult ViewResult()
        {
            return RedirectToAction("AllResult", new { message = "Views Result" });
        }

        public ActionResult TagResult()
        {
            return RedirectToAction("AllResult", new { message = "Tags Result" });
        }

        public ActionResult AllResult(string message)
        {
            ViewBag.rubrik = message;
            return View();
        }



        public ActionResult CreatePost()
        {
            return View();
        }


    }
}
