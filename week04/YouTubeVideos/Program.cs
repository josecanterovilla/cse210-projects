using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learn C# in 10 Minutes", "CodeWithMaria", 612);
        video1.AddComment(new Comment("Daniel", "Great explanation, very clear!"));
        video1.AddComment(new Comment("Sofia", "This helped me finally understand classes."));
        video1.AddComment(new Comment("Marcus", "Could you make one about interfaces next?"));
        videos.Add(video1);

        Video video2 = new Video("Top 5 Budget Laptops of the Year", "TechReviewsPro", 845);
        video2.AddComment(new Comment("Ana", "I bought the second one and love it."));
        video2.AddComment(new Comment("Liam", "Battery life numbers look a bit optimistic."));
        video2.AddComment(new Comment("Camila", "Thanks, this saved me a lot of research."));
        video2.AddComment(new Comment("Jorge", "Do you recommend any for programming?"));
        videos.Add(video2);

        Video video3 = new Video("Easy Homemade Pizza Dough", "KitchenStories", 427);
        video3.AddComment(new Comment("Valentina", "Made this tonight and it came out perfect."));
        video3.AddComment(new Comment("Noah", "Can I use whole wheat flour instead?"));
        video3.AddComment(new Comment("Isabel", "My kids loved it, thank you!"));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
