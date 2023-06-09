﻿using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels;
public partial class ScheduleViewModel : ObservableObject
{
    public int Day { get; set; }
    public ObservableRangeCollection<Grouping<string, Session>> Schedule { get; } = new();
    Random random = new();

    public ScheduleViewModel()
    {

    }

    [RelayCommand]
    Task LoadDataAsync()
    {
        var sessioncount = new[] { 1, 2, 4, 4, 4, 4, 4 };
        var sessions = new List<Session>();
        var start = new DateTime(2023, 9, Day, 8, 30, 0);
        for (int i = 0; i < sessioncount.Length; i++)
            AddItems(sessioncount[i], i);

        var sorted = from session in sessions
                     orderby session.Start
                     group session by session.StartTimeDisplay into sessiongroup
                     select new Grouping<string, Session>(sessiongroup.Key, sessiongroup);

        Schedule.AddRange(sorted);

        return Task.CompletedTask;


        void AddItems(int count, int offset)
        {
            for (int i = 0; i < count; i++)
            {
                sessions.Add(new Session
                {
                    Title = string.Join(" ", ReceiveTheJeff(random.Next(2, 5), JeffsumType.Words)),
                    Description = ReceiveTheJeff(1).First(),
                    Room = "Goldblum",
                    Start = start.AddHours(offset),
                    End = start.AddHours(offset + 1)
                });
            }
        }
    }
}


