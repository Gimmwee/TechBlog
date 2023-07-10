
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TechBlog.Core.Models;

namespace TechBlog.Core.DataContext
{
    public static class TechBlogInitializer
    {
        /// <summary>
        /// add data to other class
        /// </summary>
        /// <param name="builder"></param>
        public static void SeedData(this ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Chân dung giám đốc trốn nợ được ông Chung cho làm dự án cây xanh",
                    UrlSlug = "chan-dung-giam-dc-trn-n-duc-ong-chung-cho-lam-d-an-cay-xanh",
                    Desciption = "This is an example page for demonstration purposes.",
                },
                new Category    
                {
                    CategoryId = 2,
                    Name = "About Us",
                    UrlSlug = "about-us",
                    Desciption = "Learn more about our company and what we do.",
                },
                new Category
                {
                    CategoryId = 3,
                    Name = "Contact to customer",
                    UrlSlug = "contact-to-customer",
                    Desciption = "Get in touch with us for any questions or inquiries.",
                },
                new Category
                {
                    CategoryId = 4,
                    Name = "Product Reviews",
                    UrlSlug = "product-reviews",
                    Desciption = "Read our reviews of the latest tech gadgets and consumer products.",
                },
                new Category
                {
                    CategoryId = 5,
                    Name = "Health and Wellness",
                    UrlSlug = "health-and-wellness",
                    Desciption = "Discover tips and advice for living a healthy and balanced life.",
                },
                new Category
                {
                    CategoryId = 6,
                    Name = "Travel and Leisure",
                    UrlSlug = "travel-and-leisure",
                    Desciption = "Explore new destinations and plan your next vacation with our travel guides.",
                },
                new Category
                {
                    CategoryId = 7,
                    Name = "Food and Drink",
                    UrlSlug = "food-and-drink",
                    Desciption = "Discover new recipes, cooking techniques, and dining experiences.",
                },
                new Category
                {
                    CategoryId = 8,
                    Name = "Career Development",
                    UrlSlug = "career-development",
                    Desciption = "Learn new skills and advance your career with our expert advice and resources.",
                },
                new Category
                {
                    CategoryId = 9,
                    Name = "Home and Garden",
                    UrlSlug = "home-and-garden",
                    Desciption = "Find inspiration and advice for improving your living space and outdoor areas.",
                },
                new Category
                {
                    CategoryId = 10,
                    Name = "Sports and Fitness",
                    UrlSlug = "sports-and-fitness",
                    Desciption = "Get in shape and stay active with our fitness tips and coverage of the latest sports news.",
                }



            );

            builder.Entity<Post>().HasData(
                new Post
                {
                    PostId = 1,
                    Title = "ASEAN Countries Take Steps to Reduce Reliance on US Dollar for Trade Settlements",
                    Image= "https://images.techeblog.com/wp-content/uploads/2023/07/09135001/god-of-war-ragnarok-demake-ps1.jpg",
                    ShortDescription = "The finance ministers and central bank governors of the Association of Southeast Asian Nations (ASEAN) are exploring ways to decrease their countries’ dependence on the U.S. dollar and promote the use of local currencies in trade settlements. “We must remember the sanctions imposed by the US on Russia,” said Indonesian President Joko Widodo.",
                    PostContent = "The finance ministers and central bank governors of the Association of Southeast Asian Nations (ASEAN) held a meeting on March 30-31 in Bali, Indonesia. One of the topics they discussed was reducing reliance on western currencies, such as the U.S. dollar. ASEAN comprises Brunei, Cambodia, Indonesia, Laos, Malaysia, Myanmar, the Philippines, Singapore, Thailand, and Vietnam.\r\n\r\nThe meeting was also attended by representatives from six international\r\norganizations, namely Asian Development Bank (ADB), ASEAN+3 Macroeconomic Research Office (AMRO), the International Monetary Fund (IMF), the Financial Supervisory Board (FSB), the Bank for International Settlement (BIS), and the World Bank.\r\n\r\nAt the conclusion of the two-day meeting, the ASEAN finance ministers and central bank governors released a joint statement, stating that they agreed to “reinforce financial resilience, among others, through the use of local currency to support cross-border trade and investment in the ASEAN region.”",
                    UrlSlug = "asean-countries-take-steps-to-reduce-reliance-on-us-dollar-for-trade-settlements",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 1,
                    ViewCount = 23,
                    RateCount = 2,
                    TotalRate = 32,
                },
                 new Post
                 {
                     PostId = 2,
                     Title = "Alleged Kenyan Bill Proposes Widening Definition of Securities to Include Crypto Assets",
                     ShortDescription = "A bill seeking to put blockchain and crypto assets under the purview of the Kenyan Capital Markets Authority is supposedly set to be debated in the country’s parliament. The bill also seeks to “widen the meaning of ‘securities’ to capture digital currencies.” The persons that receive licenses from the regulator are also required to maintain records of all digital currency transactions and to pay taxes on any gains made.",
                     Image = "https://images.techeblog.com/wp-content/uploads/2023/07/09130532/kasa-smart-plug-hs103p4-smart-home-wifi-outlet.jpg",
                     PostContent = "According to Amboko Julians, a Kenyan economist and blogger, the East African nation’s parliament is set to debate a bill that proposes to place blockchain technology and digital currencies under the purview of Kenya’s Capital Markets Authority (CMA). Besides seeking to incorporate the definitions of blockchain and cryptocurrencies, Julians claimed that the bill also proposes “to widen the meaning of ‘securities’ to capture digital currencies.”\r\n\r\nIn his March 28 Twitter thread, Julians shared the supposed screenshots of the bill that is being sponsored by the Kenyan legislator Abraham Kipsang Kirwa. As shown in the screenshots, Kirwa’s bill proposes that persons seeking to introduce a cryptocurrency must first obtain a license from the capital markets regulator.",
                     UrlSlug = "alleged-kenyan-bill-proposes-widening-definition-of-securities-to-include-crypto-assets",
                     Published = true,
                     PostedOn = DateTime.Now,
                     Modified = DateTime.Now,
                     CategoryId = 2,
                     ViewCount = 223,
                     RateCount = 23,
                     TotalRate = 14,
                 },
                  new Post
                  {
                      PostId = 3,
                      Title = "10 Tips for Better Time Management",
                      ShortDescription = "Learn how to manage your time more effectively with these 10 simple tips.",
                      Image= "https://images.techeblog.com/wp-content/uploads/2023/07/09122748/smart-soft-robotic-glove-relearn-piano-strokes.jpg",
                      PostContent = "Time management is an essential skill for success in both personal and professional life. In this article, we will share 10 tips for better time management, including setting goals, prioritizing tasks, minimizing distractions, and delegating responsibilities. By following these tips, you can improve your productivity, reduce stress, and achieve your goals more efficiently.",
                      UrlSlug = "10-tips-for-better-time-management",
                      Published = false,
                      PostedOn = DateTime.Now,
                      Modified = DateTime.Now,
                      CategoryId = 3,
                      ViewCount = 111,
                      RateCount = 22,
                      TotalRate = 44,
                  },
                  new Post
                  {
                      PostId = 4,
                      Title = "Regulators Should Heed Crypto Risks When Innovating Regulation, Says Chinese Central Bank Official",
                      ShortDescription = "A senior People’s Bank of China (PBOC) official has urged regulators to consider cryptocurrency risks and fraud that could lead to bank failures when innovating regulation. ",
                      Image= "https://images.techeblog.com/wp-content/uploads/2023/07/09122748/smart-soft-robotic-glove-relearn-piano-strokes.jpg",
                      PostContent = "Xuan Changneng, a deputy governor at the People’s Bank of China (PBOC), the Chinese central bank, spoke at the Boao Forum on Friday about the potential dangers of financial innovations, including cryptocurrencies, that could cause banks and lenders to fail. He was quoted by Bloomberg as saying:\r\n\r\nRisks and fraud associated with cryptocurrency, including the two American banks who ran into troubles after providing many services for cryptocurrency from taking deposits to settlement, showed that regulators should respect rules when innovating regulation.",
                      UrlSlug = "regulators-should-heed-crypto-risks-when-innovating-regulation-says-chinese-central-bank-official",
                      Published = true,
                      PostedOn = DateTime.Now,
                      Modified = DateTime.Now,
                      CategoryId = 4,
                      ViewCount = 222,
                      RateCount = 33,
                      TotalRate = 66,
                  },
                  new Post
                  {
                      PostId = 5,
                      Title = "Building a Mobile App with React Native",
                      ShortDescription = "Learn how to build a mobile app using React Native framework.",
                     Image = "https://images.techeblog.com/wp-content/uploads/2023/07/09085915/apple-car-audio-system-patent-leak.jpg",
                      PostContent = "React Native is a popular framework for building native mobile apps using JavaScript and React. In this tutorial, we will cover the basics of React Native, including components, styling, navigation, and data management. By the end of this tutorial, you will have a working mobile app that you can deploy on both iOS and Android devices.",
                      UrlSlug = "building-a-mobile-app-with-react-native",
                      Published = true,
                      PostedOn = DateTime.Now,
                      Modified = DateTime.Now,
                      CategoryId = 5,
                      ViewCount = 333,
                      RateCount = 11,
                      TotalRate = 22,
                  },
                  new Post
                  {
                      PostId = 6,
                      Title = "How to Start a Blog",
                      ShortDescription = "Learn how to start a blog and share your ideas with the world.",
                      Image = "https://images.techeblog.com/wp-content/uploads/2023/07/09000959/nasa-valkyrie-humanoid-robot-australia-testing.jpg",
                      PostContent = "Starting a blog is a great way to express your creativity, share your knowledge, and connect with like-minded people. In this tutorial, we will cover the basics of starting a blog, including choosing a niche, selecting a platform, setting up your website, and creating content. Whether you want to blog for fun or profit, this tutorial will help you get started.",
                      UrlSlug = "how-to-start-a-blog",
                      Published = true,
                      PostedOn = DateTime.Now,
                      Modified = DateTime.Now,
                      CategoryId = 6,
                      ViewCount = 444,
                      RateCount = 44,
                      TotalRate = 88,
                  },
                  new Post
                  {
                      PostId = 7,
                      Title = "Mastering Git and GitHub",
                      ShortDescription = "Learn how to use Git and GitHub for version control and collaboration.",
                      Image= "https://images.techeblog.com/wp-content/uploads/2023/07/08224546/project-e-ink-front-page-new-york-times.jpg",
                      PostContent = "Git is a popular version control system that is widely used in software development to manage changes to source code. GitHub is a web-based platform that provides hosting for Git repositories and a range of collaboration features. In this tutorial, we will cover the basics of Git and GitHub, including creating repositories, branching, merging, and pull requests. By the end of this tutorial, you will be able to use Git and GitHub to manage your own projects and collaborate with others.",
                      UrlSlug = "mastering-git-and-github",
                      Published = true,
                      PostedOn = DateTime.Now,
                      Modified = DateTime.Now,
                      CategoryId = 7,
                      ViewCount = 234,
                      RateCount = 32,
                      TotalRate = 12,
                  },
                  new Post
                  {
                      PostId = 8,
                      Title = "The Benefits of Yoga",
                      ShortDescription = "Learn about the physical and mental benefits of practicing yoga regularly.",
                      Image = "https://images.techeblog.com/wp-content/uploads/2023/07/08202426/pokemon-sleep-ios-android-release.jpg",
                      PostContent = "Yoga is a mind-body practice that has been around for thousands of years. It involves physical postures, breathing techniques, and meditation or relaxation. Regular practice of yoga has been shown to improve flexibility, strength, balance, and reduce stress and anxiety. In this article, we will discuss the benefits of yoga and how you can incorporate it into your daily routine.",
                      UrlSlug = "the-benefits-of-yoga",
                      Published = true,
                      PostedOn = DateTime.Now,
                      Modified = DateTime.Now,
                      CategoryId = 8,
                      ViewCount = 234,
                      RateCount = 32,
                      TotalRate = 12,
                  },
                  new Post
                  {
                      PostId = 9,
                      Title = "How to Start a Successful Business",
                      ShortDescription = "Learn the key steps to starting and growing a successful business.",
                     
                      Image = "https://images.techeblog.com/wp-content/uploads/2023/07/08191929/prime-deal-3rd-gen-echo-show-5.jpg",
                      PostContent = "Starting a successful business requires careful planning, research, and execution. In this article, we will cover the key steps to starting a successful business, including identifying a profitable niche, conducting market research, developing a business plan, and marketing your business. We will also discuss some common challenges and how to overcome them.",
                      UrlSlug = "how-to-start-a-successful-business",
                      Published = true,
                      PostedOn = DateTime.Now,
                      Modified = DateTime.Now,
                      CategoryId = 9,
                      ViewCount = 123,
                      RateCount = 41,
                      TotalRate = 32,
                  },
                  new Post
                  {
                      PostId = 10,
                      Title = "The Importance of Self-Care",
                      ShortDescription = "Learn why self-care is essential for overall well-being and how to practice it.",
                     
                      Image = "https://images.techeblog.com/wp-content/uploads/2023/07/08134634/james-webb-space-telescope-most-distant-active-supermassive-black-hole-ceers-1019.jpg",
                      PostContent = "Self-care is the practice of taking care of oneself to maintain physical, mental, and emotional health. It involves activities such as eating healthy, getting enough sleep, exercising regularly, and engaging in activities that bring joy and relaxation. In this article, we will discuss the importance of self-care and provide tips for how to practice it.",
                      UrlSlug = "the-importance-of-self-care",
                      Published = true,
                      PostedOn = DateTime.Now,
                      Modified = DateTime.Now,
                      CategoryId = 10,
                      ViewCount = 223,
                      RateCount = 23,
                      TotalRate = 46,
                  },
                  new Post
                  {
                      PostId = 11,
                      Title = "How to Learn a New Language",
                      ShortDescription = "Learn effective strategies for learning a new language, whether for travel or personal growth.",
                      Image = "https://www.techeblog.com/wp-content/uploads/2023/04/hubble-space-telescope-runaway-black-hole-star-trail.jpg",
                      PostContent = "Learning a new language can be challenging, but it can also be a rewarding and enriching experience. In this article, we will discuss effective strategies for learning a new language, including setting realistic goals, practicing regularly, immersing yourself in the language, and using language learning apps and resources.",
                      UrlSlug = "how-to-learn-a-new-language",
                      Published = true,
                      PostedOn = DateTime.Now,
                      Modified = DateTime.Now,
                      CategoryId = 2,
                      ViewCount = 543,
                      RateCount = 12,
                      TotalRate = 48,
                  },
                  new Post
                  {
                      PostId = 12,
                      Title = "The Benefits of Mindfulness Meditation",
                      ShortDescription = "Learn about the benefits of mindfulness meditation and how to incorporate it into your daily routine.",
                      Image = "https://www.techeblog.com/wp-content/uploads/2023/01/hubble-space-telescope-scattered-stars-globular-cluster-ngc-6355.jpg",
                      PostContent = "Mindfulness meditation is a practice that involves focusing your attention on the present moment, without judgment. It has been shown to reduce stress, anxiety, and depression, as well as improve overall well-being. In this article, we will discuss the benefits of mindfulness meditation and provide tips for how to incorporate it into your daily routine.",
                      UrlSlug = "the-benefits-of-mindfulness-meditation",
                      Published = true,
                      PostedOn = DateTime.Now,
                      Modified = DateTime.Now,
                      CategoryId = 2,
                      ViewCount = 113,
                      RateCount = 23,
                      TotalRate = 48,
                  }
            );

            builder.Entity<PostTagMap>().HasData(
                new PostTagMap
                {
                    PostId = 1,
                    TagId = 1
                },
                new PostTagMap
                {
                    PostId = 2,
                    TagId = 2
                },
                new PostTagMap
                {
                    PostId = 3,
                    TagId = 3
                }
            );
            builder.Entity<Tag>().HasData(
                new Tag
                {
                    TagId = 1,
                    Name = "C#",
                    UrlSlug = "c-sharp",
                    Description = "C# programming language",
                    Count = 2
                },
                new Tag
                {
                    TagId = 2,
                    Name = "Responsive Design",
                    UrlSlug = "responsive-design",
                    Description = "Creating responsive web layouts",
                    Count = 1
                },
                new Tag
                {
                    TagId = 3,
                    Name = "Time Management",
                    UrlSlug = "time-management",
                    Description = "Tips for better time management",
                    Count = 3
                }
            );
            builder.Entity<Comment>().HasData(
               new Comment
               {
                   CommentId = 1,
                   Name = "John Smith",
                   Email = "john.smith@example.com",
                   PostId = 1,
                   CommentHeader = "Great article!",
                   CommentText = "This article provided a lot of useful information. I learned a lot from it. Thank you!",
                   CommentTime = DateTime.Now,
               },
               new Comment
               {
                   CommentId = 13,
                   Name = "KienDc",
                   Email = "jane.doe@example.com",
                   PostId = 3,
                   CommentHeader = "Interesting perspective!",
                   CommentText = "I never thought about the topic from this angle before. Your article gave me a lot to think about. Thanks for sharing!",
                   CommentTime = DateTime.Now,
               },
               new Comment
               {
                   CommentId = 12,
                   Name = "Son PP",
                   Email = "SonPP@example.com",
                   PostId = 2,
                   CommentHeader = "Question about the topic",
                   CommentText = "I have a question about one of the points you made in the article. Can you provide more information about XYZ? Thanks!",
                   CommentTime = DateTime.Now,
               },
               new Comment
               {
                   CommentId = 14,
                   Name = "John Smith",
                   Email = "john.smith@example.com",
                   PostId = 2,
                   CommentHeader = "Great article!",
                   CommentText = "This article provided a lot of useful information. I learned a lot from it. Thank you!",
                   CommentTime = DateTime.Now,
               },

new Comment
{
    CommentId = 2,
    Name = "Emily Jones",
    Email = "emily.jones@example.com",
    PostId = 2,
    CommentHeader = "Excellent post!",
    CommentText = "I really enjoyed reading this post. The examples were very helpful.",
    CommentTime = DateTime.Now,
},

new Comment
{
    CommentId = 3,
    Name = "David Lee",
    Email = "david.lee@example.com",
    PostId = 2,
    CommentHeader = "Thanks for sharing",
    CommentText = "This post helped me understand machine learning better. Keep up the good work!",
    CommentTime = DateTime.Now,
},

new Comment
{
    CommentId = 4,
    Name = "Sarah Johnson",
    Email = "sarah.johnson@example.com",
    PostId = 1,
    CommentHeader = "Insightful article",
    CommentText = "I learned a lot from this post. Thank you for sharing your knowledge with us.",
    CommentTime = DateTime.Now,
},

new Comment
{
    CommentId = 5,
    Name = "Michael Brown",
    Email = "michael.brown@example.com",
    PostId = 5,
    CommentHeader = "Well-written post",
    CommentText = "This post was easy to read and understand. The examples were very helpful.",
    CommentTime = DateTime.Now,
},

new Comment
{
    CommentId = 6,
    Name = "Linda Davis",
    Email = "linda.davis@example.com",
    PostId = 4,
    CommentHeader = "Thank you for this post",
    CommentText = "I was struggling to understand machine learning before reading this post. It has helped me a lot.",
    CommentTime = DateTime.Now,
},

new Comment
{
    CommentId = 7,
    Name = "Tom Smith",
    Email = "tom.smith@example.com",
    PostId = 3,
    CommentHeader = "Great job!",
    CommentText = "This post was very informative. I learned a lot from it.",
    CommentTime = DateTime.Now,
},

new Comment
{
    CommentId = 8,
    Name = "Katie Lee",
    Email = "katie.lee@example.com",
    PostId = 2,
    CommentHeader = "Thanks for sharing your knowledge",
    CommentText = "This post was well-written and very informative. I appreciate you sharing your knowledge with us.",
    CommentTime = DateTime.Now,
},

new Comment
{
    CommentId = 9,
    Name = "Peter Johnson",
    Email = "peter.johnson@example.com",
    PostId = 1,
    CommentHeader = "Very helpful post",
    CommentText = "I was looking for an introduction to machine learning and this post was exactly what I needed. Thank you!",
    CommentTime = DateTime.Now,
},

new Comment
{
    CommentId = 10,
    Name = "Amanda Brown",
    Email = "amanda.brown@example.com",
    PostId = 2,
    CommentHeader = "Thanks for the explanation",
    CommentText = "This post explained machine learning in a way that was easy to understand. I appreciate it!",
    CommentTime = DateTime.Now,
}
           );

        }
    }
}
