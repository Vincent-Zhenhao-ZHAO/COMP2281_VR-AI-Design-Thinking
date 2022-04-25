const express = require('express');
const mongoose = require('mongoose');
const User = require('./models/user');
const Component = require('./models/component');
const fs = require('fs');

// express app
const app = express();

// connect to mongodb
const db = require('mongodb');
const dbURI='mongodb+srv://admin:IBMadmin2022@cluster0.wagkr.mongodb.net/database?retryWrites=true&w=majority';
mongoose.connect(dbURI)
    .then(r => app.listen(3000) )
    .catch((err) => console.log(err));

// mongoose and mongo sandbox routes
// create user
// 1: room 2: user 3: component
app.get('/add-user',(req,res)=>{

    const user = new User({
        user_ID: req.query.ruser_ID,
        name: req.query.rname,
        password: req.query.rpassword
    });

    user.save()
        .then(r =>{
            res.send(r)
        })
        .catch((e)=>{
            console.log(e);
        });
})

// create component
app.get('/add-component', (req, res) => {

    const component = new Component({
        component_ID:req.query.rcomponent_ID,
        component_type:'sticky-note',
        content:req.query.rcontent
    });

    component.save()
        .then(r => {
            res.send(r)
        })
        .catch((e)=>{
            console.log(e);
        });
})

//update content
app.get('/update',(req,res)=>{
    Component.findOneAndUpdate(
        {$component_type:'sticky-note'},
        {$set:{content:req.query.rcontent}},
        function(err,doc){
            if (err) {
                throw err;
            }
            else {
                console.log("Updated");
            }
        })
})

// select and export content
app.get('/export-content',(req,res)=>{
    Component.find(
        {component_type:'sticky-note'},
        'content',
        function (err, docs){
            const content=JSON.stringify(docs[0].content)
            fs.writeFile('user.json', content, (err) => {
                if (err) {
                    throw err;
                }
                console.log("JSON data is saved.");
            });
        })
})
