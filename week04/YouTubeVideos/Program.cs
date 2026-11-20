using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Best Budget Headphones of 2026", "TechWithTom", 612);
        video1.AddComment(new Comment("Ana Costa", "Just bought the second pair, they sound great!"));
        video1.AddComment(new Comment("Mike R.", "Can you review the noise cancelling next?"));
        video1.AddComment(new Comment("Lucas Ferreira", "Very honest review, thanks."));
        videos.Add(video1);

        Video video2 = new Video("10-Minute Morning Workout", "FitWithSarah", 645);
        video2.AddComment(new Comment("Jenny Park", "Doing this every day before work."));
        video2.AddComment(new Comment("Carlos M.", "What brand are those resistance bands?"));
        video2.AddComment(new Comment("Emily Stone", "Short and effective, love it."));
        video2.AddComment(new Comment("David Lee", "Day 5 and I can feel the difference!"));
        videos.Add(video2);

        Video video3 = new Video("Easy Homemade Pizza Recipe", "ChefMarco", 438);
        video3.AddComment(new Comment("Rita Alves", "Made this tonight, my family loved it."));
        video3.AddComment(new Comment("Sam Wilson", "Which flour did you use?"));
        video3.AddComment(new Comment("Hannah Brown", "That oven looks amazing."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}