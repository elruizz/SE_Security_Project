const electron = require('electron');
const url = require('url');
const path = require('path');

const isMac = process.platform === 'darwin' //checks if Mac possibly mac global bool to make mulit OS cases more streamline

const {app, BrowserWindow, Menu, ipcMain} = electron; //from Traversy: Build an Electron App in Under 60 Minutes

var ipc = require('electron').ipcMain; //for change window buttonss

let mainWindow;

// Listen for the app to be ready
app.on('ready', function(){
  // create main window
  mainWindow = new BrowserWindow({
    webPreferences: {
      nodeIntegration: true
    }
  })
  // load html file
  mainWindow.loadURL(url.format({
    pathname: path.join(__dirname, "main_window.html"),
    protocol: "file",
    slashes: true
  }));

  //button event listenter to load read/write windows
  ipc.on('show_r', function(event, data){
      var result = mainWindow.loadURL('file://' + __dirname + '/read_window.html')
      event.sender.send('actionReply', result);
  });

  ipc.on('show_w', function(event, data){
    var result = mainWindow.loadURL('file://' + __dirname + '/write_window.html')
    event.sender.send('actionReply', result);
  });

  mainWindow.on('closed', function(){
    app.quit();
  });
  // build menu from template
  const mainMenu = Menu.buildFromTemplate(mainMenuTemplate);

  // insert menu
  Menu.setApplicationMenu(mainMenu);
});

// Handle create Read window
function createReadWindow(){
  // create new window
  readWindow = new BrowserWindow({
    webPreferences: {
      nodeIntegration: true
    },
    title: 'OMNIKey Reader'
  });
  // load html file
  readWindow.loadURL(url.format({
    pathname: path.join(__dirname, 'read_window.html'),
    protocol: "file",
    slashes: true
  }));

  // garbage collection
  readWindow.on('close', function(){
    addWindow = null;
  });
}

function createWriteWindow(){
  // create new window
  writeWindow = new BrowserWindow({
    webPreferences: {
      nodeIntegration: true
    },
    title: 'OMNIKey Writer'
  });
  // load html file
  writeWindow.loadURL(url.format({
    pathname: path.join(__dirname, 'write_window.html'),
    protocol: "file",
    slashes: true
  }));

  // garbage collection
  writeWindow.on('close', function(){
    addWindow = null;
  });
}

// create menu template
const mainMenuTemplate = [
  {
    label: 'File',
    submenu: [
      {
        label: 'Read',
        click(){
          createReadWindow();
        }
      },
      {
        label: 'Write'
      },
      {
        label: 'Quit',
        accelerator: process.platform == 'darwin' ? 'Command+Q':
        'Ctrl+Q',
        click(){
          app.quit();
        }
      }
    ]
  }
];



//shift menu over for mac
if(process.platform == 'darwin'){
  mainMenuTemplate.unshift({
    label: ''
  });
}

// add dev tools items if not in production
if(process.env.NODE_ENV !== 'production'){
  mainMenuTemplate.push({
    label: 'Dev Tools',
    submenu:[
      {
        label: 'Toggle DevTools',
        accelerator: process.platform == 'darwin' ? 'Command+I': //if mac cmd if win ctrl
        'Ctrl+I',
        click(item, focusedWindow){
          focusedWindow.toggleDevTools();
        }
      },
      {
        role: 'reload'
      }
    ]
  });
}