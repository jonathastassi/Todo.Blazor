const faker = require('faker');
const bcrypt = require('bcryptjs');

const database = { todos: [], users: []};

const salt = bcrypt.genSaltSync(10);
const hash = bcrypt.hashSync("123456", salt);

let quantityTodosOfUser = 0;
let quantityUsers = 1;

for (var i = 1; i<= 5; i++) {

    if (quantityTodosOfUser == 0) {
        quantityUsers++;
        
        database.users.push({
            id: quantityUsers,
            name: faker.name.findName(),
            email: faker.internet.email().toLowerCase(),
            password: hash
        });

        quantityTodosOfUser = Math.ceil(Math.random() * 4);
    }


    database.todos.push({
        id: i,
        Title: faker.lorem.sentence(),
        Done: faker.random.boolean(),
        CreatedAt: faker.random.boolean() ? faker.date.future() :  faker.date.past(),
        UserId: quantityUsers,
    });

    quantityTodosOfUser--;
}

console.log(JSON.stringify(database));