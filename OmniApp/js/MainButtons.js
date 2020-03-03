const electron = require('electron');
const url = require('url');
const path = require('path');

var ipc = require('electron').ipcMain; //for change window buttonss

let mainWindow;

 //button event listenter to load read/write windows
 ipc.on('show_r', function(event, data){
    var result = mainWindow.loadURL('file://' + __dirname + '/read_window.html')
    event.sender.send('actionReply', result);
});

ipc.on('show_r', function(event, data){
  var result = mainWindow.loadURL('file://' + __dirname + '/read_window.html')
  event.sender.send('actionReply', result);
});
