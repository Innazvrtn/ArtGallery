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
using static ArtGallery.Util.ConfigurationAutoMapperWeb;

namespace ArtGallery.Controllers
{
    public class HomeController : Controller
    {
        private IMapper _usermapper;
        IPostService postServis;
        public HomeController(IPostService serv)
        {
            postServis = serv;
            _usermapper = GetMapper();
        }
        public ActionResult Index()
        {
            var postp = _usermapper.Map<IEnumerable<PostDTO>, List<PostViewModel>>(postServis.GetAllPost(User.Identity.GetUserId()));
            return View(postp);
        }
        public ActionResult ViewComment(int Id)
        {
            IEnumerable<CommentDTO> comments = postServis.GetAllComment(Id);
            Mapper.Initialize(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>());
            var com = Mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>(comments);
            foreach (CommentViewModel el in com)
            {
                el.Name = postServis.Get(el.IdUserComment).Name;
            }
            return View(com);
        }
        public ActionResult Find(string name)
        {
            if (name == null)
            {
                name = "";
            }
            IEnumerable<PostDTO> posts = postServis.FindPost(name);
            var postp = _usermapper.Map<IEnumerable<PostDTO>, List<PostViewModel>>(posts);
            return View(postp);
        }

        [HttpGet]
        public ActionResult CreateComment(int? Id)
        {
            PostDTO post = postServis.GetPost(Id);
            Mapper.Initialize(cfg => cfg.CreateMap<PostDTO, CommentViewModel>()
                .ForMember("PostId", opt => opt.MapFrom(src => src.Id)));
            var comment = Mapper.Map<PostDTO, CommentViewModel>(post);
            return View(comment);


        }
        [HttpPost]
        public ActionResult CreateComment(CommentViewModel comm)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>().ReverseMap());
            var currentUserId = User.Identity.GetUserId();
            comm.IdUserComment = currentUserId;
            comm.Date = DateTime.Now;
            var comDto = Mapper.Map<CommentViewModel, CommentDTO>(comm);
            postServis.CreateComment(comDto);
            return Redirect("/Home/ViewComment/" + comDto.PostId.ToString());

        }
        [Authorize]
        [HttpGet]
        public ActionResult CreatePost()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult CreatePost(PostViewModel post, string textTag)
        {
            if (ModelState.IsValid)
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
                    post.ClientId = currentUserId;
                    List<TagViewModel> tags = new List<TagViewModel>();
                    string[] tagContext = textTag.Split(',');
                    foreach (string item in tagContext)
                    {
                        TagViewModel tagnew = null;
                        IEnumerable<TagDTO> listTag = postServis.GetTagWithName(item);
                        var listT = _usermapper.Map<IEnumerable<TagDTO>, List<TagViewModel>>(listTag);
                        if (listT.Count() > 0)
                        {
                            tagnew = listT.First();
                        }
                        else
                        {
                            tagnew = new TagViewModel();
                            tagnew.TextTag = item;
                        }
                        tags.Add(tagnew);
                    }
                    post.Tags = tags;
                    var postDto = _usermapper.Map<PostDTO>(post);
                    postServis.CreatePost(postDto);

                    return Redirect("/Home/Index");
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError(ex.Property, ex.Message);
                }
            }
            return View(post);
        }

    }
}