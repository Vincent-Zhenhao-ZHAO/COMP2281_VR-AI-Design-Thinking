const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const userSchema = new Schema({
    user_ID: {
        type: Number,
        required: true
    },
    name: {
        type: String,
        required: true
    },
    password: {
        type: String,
        require: true
    }
});

const componentSchema = new Schema({
    component_ID:{
        type: Number,
        required: true
    },
    component_type:{
        type: String,
        required: true
    },
    content:{
        type: String
    }
});

const roomSchema = new Schema({
    room_ID:{
        type:Number,
        required: true
    },
    title:{
        type: String,
        required: true
    },
    type:{
        type: String,
        required: true
    },
    users:[userSchema],
    components:[componentSchema]
}, {timestamps: true});

const room = mongoose.model('room', roomSchema);
module.exports = room;