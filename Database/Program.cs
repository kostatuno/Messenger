﻿using Database;
using Microsoft.VisualBasic.FileIO;
using Messenger.Extensions;
using Messenger;
using System.Reflection;
using Messenger.Models;

using (var db = new ApplicationDbContext())
{
    db.Database.EnsureCreated();
}

