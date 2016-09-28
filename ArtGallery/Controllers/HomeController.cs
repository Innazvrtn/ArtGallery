using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtGallery.BLL.DTO;
using ArtGallery.BLL.Infrastructure;
using ArtGallery.BLL.Interfaces;
using AutoMapper;
using ArtGallery.Models;
using Microsoft.AspNet.Identity;
using System.IO;

namespace ArtGallery.Controllers
{
    public class HomeController : Controller
    {
        IPostService postServis;
        public HomeController(IPostService serv)
        {
            postServis = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<PostDTO> posts = postServis.GetAllPost(User.Identity.GetUserId());
            Mapper.Initialize(cfg => cfg.CreateMap<PostDTO, PostViewModel>());
            var postp = Mapper.Map<IEnumerable<PostDTO>, List<PostViewModel>>(posts);
            var imagesModel = new PostViewModel();       
            foreach (var item in postp)
            {
             imagesModel.ImageList.Add(item.Photo);
            }
            return View(imagesModel);
        }

        public ActionResult Find(string name)
        {
            IEnumerable<PostDTO> posts = postServis.FindPost(name);
            Mapper.Initialize(cfg => cfg.CreateMap<PostDTO, PostViewModel>());
            var postp = Mapper.Map<IEnumerable<PostDTO>, List<PostViewModel>>(posts);
            var imagesModel = new PostViewModel();
            foreach (var item in postp)
            {
                imagesModel.ImageList.Add(item.Photo);
            }
            return View(imagesModel);
        }

        public ActionResult CreatePost()
        {
            return View();
                }

        [HttpPost]
        public ActionResult CreatePost(PostViewModel post)
        {
            try
            {
                if (Request.Files.Count != 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFileBase file = Request.Files[i];
                        int fileSize = file.ContentLength;
                        string fileName = file.FileName;
                        file.SaveAs(Server.MapPath("~/Upload_Files/" + fileName));
                        post.Photo = "~/Upload_Files/" + fileName;
                    }
                }
                
                var currentUserId = User.Identity.GetUserId();
                Mapper.Initialize(cfg => cfg.CreateMap<PostDTO, PostViewModel>().ReverseMap());
                post.ClientId = currentUserId;
                
                var postDto = Mapper.Map<PostViewModel, PostDTO>(post);
                postServis.CreatePost(postDto);
                //IEnumerable<TagDTO> tags = postServis.GetTagWithName();
                //Mapper.Initialize(cfg => cfg.CreateMap<PostDTO, PostViewModel>());
                //var postp = Mapper.Map<IEnumerable<PostDTO>, List<PostViewModel>>(posts);
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(post);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}