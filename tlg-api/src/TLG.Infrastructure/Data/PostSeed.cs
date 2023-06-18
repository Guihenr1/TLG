using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TLG.Core.Entities;

namespace TLG.Infrastructure.Data
{
  public class PostSeed
  {
    public static async Task Seed(Context context)
    {
      context.Database.Migrate();
      context.Database.EnsureCreated();

      if (!context.Contents.Any())
      {
        context.Contents.AddRange(GetPreconfiguredContents());
        await context.SaveChangesAsync();
      }
    }

    private static List<Content> GetPreconfiguredContents()
    {
      return new List<Content>
      {
        new Content{
            Id = Guid.NewGuid(),
            Title = "Post 1",
            Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et 
            magnis dis parturient montes, nascetur ridiculus mus.",
            Image = "https://img.freepik.com/free-photo/digital-painting-mountain-with-colorful-tree-foreground_1340-25699.jpg?w=900&t=st=1686975343~exp=1686975943~hmac=e6788f48ad907cf51ecbaa80eb702f11494cbb087ebc8705425b3c61ee213daf"
        },
        new Content{
            Id = Guid.NewGuid(),
            Title = "Post 2",
            Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et 
            magnis dis parturient montes, nascetur ridiculus mus.",
            Image = "https://img.freepik.com/free-photo/close-up-film-texture-details_23-2149368379.jpg?w=826&t=st=1686975487~exp=1686976087~hmac=5c262f574ab90eb574c37c23c8ec795a07ec80fa1b331af81a36d65de4da17ec"
        },
        new Content{
            Id = Guid.NewGuid(),
            Title = "Post 3",
            Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et 
            magnis dis parturient montes, nascetur ridiculus mus.",
            Image = "https://img.freepik.com/free-photo/lovely-spring-flowers-leaves-white-background-with-negative-space_1123-179.jpg?w=740&t=st=1686975489~exp=1686976089~hmac=19a756253547acefcdd61136f7fb9f3c843d372187116a047cc8a1d965904856"
        },
        new Content{
            Id = Guid.NewGuid(),
            Title = "Post 4",
            Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et 
            magnis dis parturient montes, nascetur ridiculus mus.",
            Image = "https://img.freepik.com/free-photo/authentic-anamorphic-lens-flare-with-ring-ghost-effect_53876-105282.jpg?w=900&t=st=1686975493~exp=1686976093~hmac=717256a795682c9261f29be21a822db57326dabf31a426cadda80e4337fa8858"
        },
        new Content{
            Id = Guid.NewGuid(),
            Title = "Post 5",
            Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et 
            magnis dis parturient montes, nascetur ridiculus mus.",
            Image = "https://img.freepik.com/free-photo/beige-paintbrush-stroke-textured-background_53876-129531.jpg?w=900&t=st=1686975495~exp=1686976095~hmac=75f79ec572189de466f4365eb0fc99442ba736f734edd7c03c6665dab83b3713"
        },
        new Content{
            Id = Guid.NewGuid(),
            Title = "Post 6",
            Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et 
            magnis dis parturient montes, nascetur ridiculus mus.",
            Image = "https://img.freepik.com/free-photo/water-texture-background-transparent-liquid_53876-142912.jpg?w=900&t=st=1686975498~exp=1686976098~hmac=727c180925611566586608ac07488240d4dc42d2a9b309bbc31a5735b2bb9213"
        },
        new Content{
            Id = Guid.NewGuid(),
            Title = "Post 7",
            Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et 
            magnis dis parturient montes, nascetur ridiculus mus.",
            Image = "https://img.freepik.com/free-photo/fire-flame-black-background_53876-111363.jpg?w=900&t=st=1686975505~exp=1686976105~hmac=fff36e16b670b5f5b7d865a735ef0f1674ac42180bc00080fc5009439128ac22"
        },
        new Content{
            Id = Guid.NewGuid(),
            Title = "Post 8",
            Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et 
            magnis dis parturient montes, nascetur ridiculus mus.",
            Image = "https://img.freepik.com/free-photo/wood-material-background-wallpaper-texture-concept_53876-42925.jpg?w=900&t=st=1686975509~exp=1686976109~hmac=13db646efe2a6c3bdd7291fe050120c298a684c55cbf179ddcd3f9e60b5f5285"
        },
        new Content{
            Id = Guid.NewGuid(),
            Title = "Post 9",
            Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et 
            magnis dis parturient montes, nascetur ridiculus mus.",
            Image = "https://img.freepik.com/free-photo/authentic-anamorphic-lens-flare-with-ring-ghost-effect_53876-105282.jpg?w=900&t=st=1686976053~exp=1686976653~hmac=4fcd02fbb70f4d24436505c7a6f725d5c5dda0358b00b985ce8091b5c41d5d05"
        },
        new Content{
            Id = Guid.NewGuid(),
            Title = "Post 10",
            Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et 
            magnis dis parturient montes, nascetur ridiculus mus.",
            Image = "https://img.freepik.com/free-photo/blank-phone-screen-purple-background_53876-143196.jpg?w=900&t=st=1686976062~exp=1686976662~hmac=4449f3fbfdc6cad696469570975837e876827c9a2ce9a3004e46b809a5767e14"
        },
        new Content{
            Id = Guid.NewGuid(),
            Title = "Post 11",
            Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et 
            magnis dis parturient montes, nascetur ridiculus mus.",
            Image = "https://img.freepik.com/free-photo/business-concept-with-graphic-holography_23-2149160929.jpg?w=900&t=st=1686975516~exp=1686976116~hmac=3a3eb59f0359d79a6bfdbbf1d6d9eb24adcc791eb753c9d3aef29b3ebd3fb8b1"
        },
        new Content{
            Id = Guid.NewGuid(),
            Title = "Post 12",
            Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et 
            magnis dis parturient montes, nascetur ridiculus mus.",
            Image = "https://img.freepik.com/free-photo/nature-colorful-landscape-dusk-cloud_1203-5705.jpg?w=900&t=st=1686975519~exp=1686976119~hmac=d6d43d0ed9d2345244142f47d652ccae9f2e105a02af1b7d7bd4feeea2f8936e"
        },
        new Content{
            Id = Guid.NewGuid(),
            Title = "Post 13",
            Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et 
            magnis dis parturient montes, nascetur ridiculus mus.",
            Image = "https://img.freepik.com/free-photo/white-cloud-blue-sky_74190-7709.jpg?w=900&t=st=1686975521~exp=1686976121~hmac=c453e4d36353f1fefbf39d1a13a278e254a693b3ae8d349ce2e5e33569c0f163"
        },
        new Content{
            Id = Guid.NewGuid(),
            Title = "Post 14",
            Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et 
            magnis dis parturient montes, nascetur ridiculus mus.",
            Image = "https://img.freepik.com/free-photo/low-angle-shot-mesmerizing-starry-sky_181624-27925.jpg?w=900&t=st=1686975526~exp=1686976126~hmac=962be1388d2446d3929755e19240512777eea71c1821b5fdaa0e327daf759a78"
        },
        new Content{
            Id = Guid.NewGuid(),
            Title = "Post 15",
            Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Nunc vitae dolor eget sapien semper mattis. Orci varius natoque penatibus et 
            magnis dis parturient montes, nascetur ridiculus mus.",
            Image = "https://img.freepik.com/free-photo/laptop-balancing-with-purple-background_23-2150271750.jpg?w=740&t=st=1686975751~exp=1686976351~hmac=1711212198bf74949ba41880bb86d783a946d3765499c250dc74f58a21ac3f5d"
        },
      };
    }
  }
}