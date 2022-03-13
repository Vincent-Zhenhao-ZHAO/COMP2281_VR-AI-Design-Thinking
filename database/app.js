const express = require('express');
const mongoose = require('mongoose');
const User = require('./models/user');
const Room = require('./models/room');

// express app
const app = express();

// connect to mongodb
const db = require('mongodb');
const dbURI='mongodb+srv://zcx_00:PolarBear314@cluster0.wagkr.mongodb.net/database?retryWrites=true&w=majority';
mongoose.connect(dbURI)
    .then(r => app.listen(3000) )
    .catch((err) => console.log(err));

// mongoose and mongo sandbox routes
// create user
// 1: room 2: user 3: component
app.get('/add-user',(req,res)=>{
    const user = new User({
        user_ID:res.params["id"],
        name: 'Abi',
        password:'123'
    });

    user.save()
        .then(r =>{
            res.send(r)
        })
        .catch((e)=>{
            console.log(e);
        });
})

// create room
app.get('/add-room', (req, res) => {
    const room = new Room({
        room_ID:1001,
        title:'the first room',
        type:'main',
        users:[{user_ID:2001, name:'Abi', password:'123'},{user_ID: 2002, name:'Ben', password:'456'}],
        components:[{component_ID:3001, component_type:'whiteboard',content:'Hello world'}]
    });

    room.save()
        .then(r => {
            res.send(r)
        })
        .catch((e)=>{
            console.log(e);
        });
})

// select and export content
app.get('/export-content',(req,res)=>{
    Room.find(
        {room_ID:1001},
        'components.content',
        function (err, docs){
           console.log(JSON.stringify(docs[0].components[0].content))
        })
})