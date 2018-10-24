using System;
using System.Linq;
using blogEngine.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace blogEngine.Controllers
{
    public class BlogController : Controller{

        private BloggingContext _bloggingContext;

        public BlogController(BloggingContext bloggingContext)
        {
        _bloggingContext = bloggingContext;
        }

    public IActionResult Index(){
    
      var blogs = _bloggingContext.Blogs.ToList();
      var listModel= new BlogPostList();
      listModel.Posts=blogs;
      return View(listModel);
    }
    

        /* 
        public IActionResult Index(){
            
            var listModel= new BlogPostList(){
            Posts= new System.Collections.Generic.List<BlogPost>()
            };
           listModel.Posts.Add(new BlogPost(){
                Id= 1,
               Author="Raf",
               Title= "Eerste titel",
               Content="content enzo",
               CreatedAt= DateTime.Now
           });
           listModel.Posts.Add(new BlogPost(){
                Id= 2,
               Author="Simon",
               Title= "Tweede titel",
               Content="pink fluffy unicorns",
               CreatedAt= DateTime.Now
           });
           
            return View(listModel);

        }

*/
        /*public IActionResult Detail([FromRoute] int blogId)
        {

            
           var blogPost= new BlogPost(){
                Id=1,
                Title="Eerste titel",
                Author="Raf",
                Content="Eerste Titel",
                CreatedAt= DateTime.Now
            };
            return View(blogPost);
        }*/
    // home/hello?raf/ceuls
        [HttpGet("Blog/Detail/{blogId}")]
        public IActionResult Detail([FromRoute]int blogId)
        {
            return View(new BlogPost()
            {
                Id = blogId,
                Title="shit",
                Author="Raf",
                Content="meer shit",
                CreatedAt= DateTime.Now
            });
        }

    public IActionResult Create()
            {

            var blog = new BlogPost { Id =1,
                Title="shit",
                Author="bloem",
                Content="meer shit",
                CreatedAt= DateTime.Now };
            _bloggingContext.Blogs.Add(blog);
            _bloggingContext.SaveChanges();
            return new CreatedResult(string.Empty,blog);
                //return View();
                
            }      



    }
}
    