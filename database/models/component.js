const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const componentSchema = new Schema({
    component_type:{
        type: String,
        required: true
    },
    content:{
        type: String
    }
});


const component = mongoose.model('component', componentSchema);
module.exports = component;
