// importing packages

const express = require('express');
const admin = require('firebase-admin');
const bcrypt = require('bcrypt');
const path = require('path');


// declarando static path
let staticPath = path.join(__dirname, "public");




// iniciando express.js

const app = express();

//middlewares

app.use(express.static(staticPath));

//routes
//home routes
app.get("/", (req, res) => {
    res.sendFile(path.join(staticPath, "index.html"));
})

//ruta signup
app.get('/signup', (req, res) => {
    res.sendFile(path.join(staticPath, "signup.html"));
})

// ruta 404
app.get('/404', (req, res) => {
    res.sendFile(path.join(staticPath, "404.html"));
})

app.use((req, res) =>{
    res.redirect('/404');
})


app.listen(3000, () => {
    console.log('listening on port 3000.......');
})