using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechBlog.Core.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    RateCount = table.Column<int>(type: "int", nullable: false),
                    TotalRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CommentHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagMap",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagMap", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTagMap_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagMap_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Desciption", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, "This is an example page for demonstration purposes.", "Chân dung giám đốc trốn nợ được ông Chung cho làm dự án cây xanh", "chan-dung-giam-dc-trn-n-duc-ong-chung-cho-lam-d-an-cay-xanh" },
                    { 2, "Learn more about our company and what we do.", "About Us", "about-us" },
                    { 3, "Get in touch with us for any questions or inquiries.", "Contact to customer", "contact-to-customer" },
                    { 4, "Read our reviews of the latest tech gadgets and consumer products.", "Product Reviews", "product-reviews" },
                    { 5, "Discover tips and advice for living a healthy and balanced life.", "Health and Wellness", "health-and-wellness" },
                    { 6, "Explore new destinations and plan your next vacation with our travel guides.", "Travel and Leisure", "travel-and-leisure" },
                    { 7, "Discover new recipes, cooking techniques, and dining experiences.", "Food and Drink", "food-and-drink" },
                    { 8, "Learn new skills and advance your career with our expert advice and resources.", "Career Development", "career-development" },
                    { 9, "Find inspiration and advice for improving your living space and outdoor areas.", "Home and Garden", "home-and-garden" },
                    { 10, "Get in shape and stay active with our fitness tips and coverage of the latest sports news.", "Sports and Fitness", "sports-and-fitness" }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagId", "Count", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, 2, "C# programming language", "C#", "c-sharp" },
                    { 2, 1, "Creating responsive web layouts", "Responsive Design", "responsive-design" },
                    { 3, 3, "Tips for better time management", "Time Management", "time-management" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "CategoryId", "Image", "Modified", "PostContent", "PostedOn", "Published", "RateCount", "ShortDescription", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[,]
                {
                    { 1, 1, "https://images.techeblog.com/wp-content/uploads/2023/07/09135001/god-of-war-ragnarok-demake-ps1.jpg", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1552), "The finance ministers and central bank governors of the Association of Southeast Asian Nations (ASEAN) held a meeting on March 30-31 in Bali, Indonesia. One of the topics they discussed was reducing reliance on western currencies, such as the U.S. dollar. ASEAN comprises Brunei, Cambodia, Indonesia, Laos, Malaysia, Myanmar, the Philippines, Singapore, Thailand, and Vietnam.\r\n\r\nThe meeting was also attended by representatives from six international\r\norganizations, namely Asian Development Bank (ADB), ASEAN+3 Macroeconomic Research Office (AMRO), the International Monetary Fund (IMF), the Financial Supervisory Board (FSB), the Bank for International Settlement (BIS), and the World Bank.\r\n\r\nAt the conclusion of the two-day meeting, the ASEAN finance ministers and central bank governors released a joint statement, stating that they agreed to “reinforce financial resilience, among others, through the use of local currency to support cross-border trade and investment in the ASEAN region.”", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1538), true, 2, "The finance ministers and central bank governors of the Association of Southeast Asian Nations (ASEAN) are exploring ways to decrease their countries’ dependence on the U.S. dollar and promote the use of local currencies in trade settlements. “We must remember the sanctions imposed by the US on Russia,” said Indonesian President Joko Widodo.", "ASEAN Countries Take Steps to Reduce Reliance on US Dollar for Trade Settlements", 32, "asean-countries-take-steps-to-reduce-reliance-on-us-dollar-for-trade-settlements", 23 },
                    { 2, 2, "https://images.techeblog.com/wp-content/uploads/2023/07/09130532/kasa-smart-plug-hs103p4-smart-home-wifi-outlet.jpg", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1555), "According to Amboko Julians, a Kenyan economist and blogger, the East African nation’s parliament is set to debate a bill that proposes to place blockchain technology and digital currencies under the purview of Kenya’s Capital Markets Authority (CMA). Besides seeking to incorporate the definitions of blockchain and cryptocurrencies, Julians claimed that the bill also proposes “to widen the meaning of ‘securities’ to capture digital currencies.”\r\n\r\nIn his March 28 Twitter thread, Julians shared the supposed screenshots of the bill that is being sponsored by the Kenyan legislator Abraham Kipsang Kirwa. As shown in the screenshots, Kirwa’s bill proposes that persons seeking to introduce a cryptocurrency must first obtain a license from the capital markets regulator.", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1554), true, 23, "A bill seeking to put blockchain and crypto assets under the purview of the Kenyan Capital Markets Authority is supposedly set to be debated in the country’s parliament. The bill also seeks to “widen the meaning of ‘securities’ to capture digital currencies.” The persons that receive licenses from the regulator are also required to maintain records of all digital currency transactions and to pay taxes on any gains made.", "Alleged Kenyan Bill Proposes Widening Definition of Securities to Include Crypto Assets", 14, "alleged-kenyan-bill-proposes-widening-definition-of-securities-to-include-crypto-assets", 223 },
                    { 3, 3, "https://images.techeblog.com/wp-content/uploads/2023/07/09122748/smart-soft-robotic-glove-relearn-piano-strokes.jpg", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1557), "Time management is an essential skill for success in both personal and professional life. In this article, we will share 10 tips for better time management, including setting goals, prioritizing tasks, minimizing distractions, and delegating responsibilities. By following these tips, you can improve your productivity, reduce stress, and achieve your goals more efficiently.", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1556), false, 22, "Learn how to manage your time more effectively with these 10 simple tips.", "10 Tips for Better Time Management", 44, "10-tips-for-better-time-management", 111 },
                    { 4, 4, "https://images.techeblog.com/wp-content/uploads/2023/07/09122748/smart-soft-robotic-glove-relearn-piano-strokes.jpg", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1558), "Xuan Changneng, a deputy governor at the People’s Bank of China (PBOC), the Chinese central bank, spoke at the Boao Forum on Friday about the potential dangers of financial innovations, including cryptocurrencies, that could cause banks and lenders to fail. He was quoted by Bloomberg as saying:\r\n\r\nRisks and fraud associated with cryptocurrency, including the two American banks who ran into troubles after providing many services for cryptocurrency from taking deposits to settlement, showed that regulators should respect rules when innovating regulation.", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1558), true, 33, "A senior People’s Bank of China (PBOC) official has urged regulators to consider cryptocurrency risks and fraud that could lead to bank failures when innovating regulation. ", "Regulators Should Heed Crypto Risks When Innovating Regulation, Says Chinese Central Bank Official", 66, "regulators-should-heed-crypto-risks-when-innovating-regulation-says-chinese-central-bank-official", 222 },
                    { 5, 5, "https://images.techeblog.com/wp-content/uploads/2023/07/09085915/apple-car-audio-system-patent-leak.jpg", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1560), "React Native is a popular framework for building native mobile apps using JavaScript and React. In this tutorial, we will cover the basics of React Native, including components, styling, navigation, and data management. By the end of this tutorial, you will have a working mobile app that you can deploy on both iOS and Android devices.", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1559), true, 11, "Learn how to build a mobile app using React Native framework.", "Building a Mobile App with React Native", 22, "building-a-mobile-app-with-react-native", 333 },
                    { 6, 6, "https://images.techeblog.com/wp-content/uploads/2023/07/09000959/nasa-valkyrie-humanoid-robot-australia-testing.jpg", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1561), "Starting a blog is a great way to express your creativity, share your knowledge, and connect with like-minded people. In this tutorial, we will cover the basics of starting a blog, including choosing a niche, selecting a platform, setting up your website, and creating content. Whether you want to blog for fun or profit, this tutorial will help you get started.", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1561), true, 44, "Learn how to start a blog and share your ideas with the world.", "How to Start a Blog", 88, "how-to-start-a-blog", 444 },
                    { 7, 7, "https://images.techeblog.com/wp-content/uploads/2023/07/08224546/project-e-ink-front-page-new-york-times.jpg", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1564), "Git is a popular version control system that is widely used in software development to manage changes to source code. GitHub is a web-based platform that provides hosting for Git repositories and a range of collaboration features. In this tutorial, we will cover the basics of Git and GitHub, including creating repositories, branching, merging, and pull requests. By the end of this tutorial, you will be able to use Git and GitHub to manage your own projects and collaborate with others.", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1563), true, 32, "Learn how to use Git and GitHub for version control and collaboration.", "Mastering Git and GitHub", 12, "mastering-git-and-github", 234 },
                    { 8, 8, "https://images.techeblog.com/wp-content/uploads/2023/07/08202426/pokemon-sleep-ios-android-release.jpg", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1565), "Yoga is a mind-body practice that has been around for thousands of years. It involves physical postures, breathing techniques, and meditation or relaxation. Regular practice of yoga has been shown to improve flexibility, strength, balance, and reduce stress and anxiety. In this article, we will discuss the benefits of yoga and how you can incorporate it into your daily routine.", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1565), true, 32, "Learn about the physical and mental benefits of practicing yoga regularly.", "The Benefits of Yoga", 12, "the-benefits-of-yoga", 234 },
                    { 9, 9, "https://images.techeblog.com/wp-content/uploads/2023/07/08191929/prime-deal-3rd-gen-echo-show-5.jpg", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1567), "Starting a successful business requires careful planning, research, and execution. In this article, we will cover the key steps to starting a successful business, including identifying a profitable niche, conducting market research, developing a business plan, and marketing your business. We will also discuss some common challenges and how to overcome them.", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1566), true, 41, "Learn the key steps to starting and growing a successful business.", "How to Start a Successful Business", 32, "how-to-start-a-successful-business", 123 },
                    { 10, 10, "https://images.techeblog.com/wp-content/uploads/2023/07/08134634/james-webb-space-telescope-most-distant-active-supermassive-black-hole-ceers-1019.jpg", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1568), "Self-care is the practice of taking care of oneself to maintain physical, mental, and emotional health. It involves activities such as eating healthy, getting enough sleep, exercising regularly, and engaging in activities that bring joy and relaxation. In this article, we will discuss the importance of self-care and provide tips for how to practice it.", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1568), true, 23, "Learn why self-care is essential for overall well-being and how to practice it.", "The Importance of Self-Care", 46, "the-importance-of-self-care", 223 },
                    { 11, 2, "https://www.techeblog.com/wp-content/uploads/2023/04/hubble-space-telescope-runaway-black-hole-star-trail.jpg", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1570), "Learning a new language can be challenging, but it can also be a rewarding and enriching experience. In this article, we will discuss effective strategies for learning a new language, including setting realistic goals, practicing regularly, immersing yourself in the language, and using language learning apps and resources.", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1569), true, 12, "Learn effective strategies for learning a new language, whether for travel or personal growth.", "How to Learn a New Language", 48, "how-to-learn-a-new-language", 543 },
                    { 12, 2, "https://www.techeblog.com/wp-content/uploads/2023/01/hubble-space-telescope-scattered-stars-globular-cluster-ngc-6355.jpg", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1571), "Mindfulness meditation is a practice that involves focusing your attention on the present moment, without judgment. It has been shown to reduce stress, anxiety, and depression, as well as improve overall well-being. In this article, we will discuss the benefits of mindfulness meditation and provide tips for how to incorporate it into your daily routine.", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1571), true, 23, "Learn about the benefits of mindfulness meditation and how to incorporate it into your daily routine.", "The Benefits of Mindfulness Meditation", 48, "the-benefits-of-mindfulness-meditation", 113 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId", "Published" },
                values: new object[,]
                {
                    { 1, "Great article!", "This article provided a lot of useful information. I learned a lot from it. Thank you!", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1607), "john.smith@example.com", "John Smith", 1, false },
                    { 2, "Excellent post!", "I really enjoyed reading this post. The examples were very helpful.", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1611), "emily.jones@example.com", "Emily Jones", 2, false },
                    { 3, "Thanks for sharing", "This post helped me understand machine learning better. Keep up the good work!", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1612), "david.lee@example.com", "David Lee", 2, false },
                    { 4, "Insightful article", "I learned a lot from this post. Thank you for sharing your knowledge with us.", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1613), "sarah.johnson@example.com", "Sarah Johnson", 1, false },
                    { 5, "Well-written post", "This post was easy to read and understand. The examples were very helpful.", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1614), "michael.brown@example.com", "Michael Brown", 5, false },
                    { 6, "Thank you for this post", "I was struggling to understand machine learning before reading this post. It has helped me a lot.", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1614), "linda.davis@example.com", "Linda Davis", 4, false },
                    { 7, "Great job!", "This post was very informative. I learned a lot from it.", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1615), "tom.smith@example.com", "Tom Smith", 3, false },
                    { 8, "Thanks for sharing your knowledge", "This post was well-written and very informative. I appreciate you sharing your knowledge with us.", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1616), "katie.lee@example.com", "Katie Lee", 2, false },
                    { 9, "Very helpful post", "I was looking for an introduction to machine learning and this post was exactly what I needed. Thank you!", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1617), "peter.johnson@example.com", "Peter Johnson", 1, false },
                    { 10, "Thanks for the explanation", "This post explained machine learning in a way that was easy to understand. I appreciate it!", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1618), "amanda.brown@example.com", "Amanda Brown", 2, false },
                    { 12, "Question about the topic", "I have a question about one of the points you made in the article. Can you provide more information about XYZ? Thanks!", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1609), "SonPP@example.com", "Son PP", 2, false },
                    { 13, "Interesting perspective!", "I never thought about the topic from this angle before. Your article gave me a lot to think about. Thanks for sharing!", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1608), "jane.doe@example.com", "KienDc", 3, false },
                    { 14, "Great article!", "This article provided a lot of useful information. I learned a lot from it. Thank you!", new DateTime(2023, 7, 26, 9, 32, 41, 314, DateTimeKind.Local).AddTicks(1610), "john.smith@example.com", "John Smith", 2, false }
                });

            migrationBuilder.InsertData(
                table: "PostTagMap",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMap_TagId",
                table: "PostTagMap",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostTagMap");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
