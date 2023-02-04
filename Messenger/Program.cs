using Microsoft.VisualBasic.FileIO;
using Messenger.Extensions;
using Messenger;
using System.Reflection;
using Messenger.Entities;
using Messenger.Services;
using Messenger.Data;

var client = new ConsoleClient(
    new Registration(),
    new Authorization());

