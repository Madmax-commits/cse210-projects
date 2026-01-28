using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C#", "Code Academy", 600);
        video1.AddComment(new Comment("Alice", "Very helpful tutorial!"));
        video1.AddComment(new Comment("Bob", "Clear explanation."));
        video1.AddComment(new Comment("Charlie", "Loved this video."));
        videos.Add(video1);

        Video video2 = new Video("OOP Principles Explained", "Tech World", 720);
        video2.AddComment(new Comment("Dana", "Great breakdown of abstraction."));
        video2.AddComment(new Comment("Eli", "This finally makes sense."));
        video2.AddComment(new Comment("Faith", "Thanks for this!"));
        videos.Add(video2);

        Video video3 = new Video("Understanding Lists in C#", "Dev Simplified", 540);
        video3.AddComment(new Comment("Grace", "Lists are so powerful."));
        video3.AddComment(new Comment("Henry", "Nice examples."));
        video3.AddComment(new Comment("Ivy", "Well explained."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
