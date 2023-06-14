"use strict"

import express from 'express'
import mysql from 'mysql2/promise'
import fs from 'fs'

const app = express()
const port = 5500


app.use(express.json())
app.use(express.static('./public'))

3
async function connectToDB() //la conexion a la base de datos es una promesa
{
    return await mysql.createConnection({
        host:'localhost',
        user:'arepita1',
        password:'Arepita1',
        database:'vg_db'
    })
}

app.get('/', (request,response)=>{
    fs.readFile('./public/index-1.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err)
        console.log('Loading page...')
        response.send(html)
    })
})

app.get('/api/users', async (request, response)=>{ //definir un endpoint
    let connection = null
    //se hace la conexion y un query y después cierra la conexion

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from Usuario')
        //en execute le estamos pidiendo q selecciones toda la tabla de users
        //sigue siendo una promesa entonces usamos await
        //results es un array de objetos, cada objeto es un usuario, viene la info por query
        //fields es un array de objetos, cada objeto es un campo de la tabla
        console.log(`${results.length} rows returned`)//muestra los resultados en consola
        response.json(results)
        //formato json, cuyos atributos serán los nombres de columnas y los valores serán la info de las filas
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally //siempre se ejecuta con o sin error, cierra la conexion
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

app.get('/api/users/:id', async (request, response)=> // ya le manda un parámetro
{
    let connection = null

    try
    {
        connection = await connectToDB()

        const [results_user, _] = await connection.query('select * from Usuario where identifier= ?', [request.params.id])
        
        console.log(`${results_user.length} rows returned`)
        response.json(results_user)
        //ya no manda una sentencia de sql sino un query
        //connection.query me permite pasar parámetros
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

app.post('/api/users', async (request, response)=>{ // se usa post porque se quiere insertar algo

    let connection = null

    try
    {    
        connection = await connectToDB()

        const [results, fields] = await connection.query('insert into Usuario set ?', request.body)
        //request.body es un objeto que contiene los datos que se quieren insertar
        
        console.log(`${results.affectedRows} row inserted`)
        response.json({'message': "Data inserted correctly.", "id": results.insertId})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

app.post('/api/users/login', async (request, response) => {
    const { username, password } = request.body;
  
    let connection = null;
  
    try {
      connection = await connectToDB();
  
      const [results] = await connection.query('SELECT * FROM Usuario WHERE username = ? AND password = ?', [
        username,
        password
      ]);
  
      if (results.length > 0) {
        response.json({ message: 'Inicio de sesión exitoso' });
      } else {
        response.status(401).json({ error: 'Credenciales inválidas' });
      }
    } catch (error) {
      response.status(500).json({ error: 'Error en el servidor' });
    } finally {
      if (connection !== null) {
        connection.end();
        console.log('Connection closed successfully!');
      }
    }
  });
  //BORRAR
  app.get('/api/levels', async(request, response)=>{
    
    let connection = null;
    

    try{

        connection = await connectToDB();

        const [results] = await connection.query('select * from level where completion_rate is not null order by completion_rate desc limit 5')
        //LEADERBOARD DE NIVELES
        //TOP 5 EN RELACIÓN A COMPLETION_RATE
            
            console.log("Sending data correctly.")
            response.status(200)
            response.json(results)
        }

        
    
    catch(error)
    {
        console.log(error)
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        connection.end()
    }
}) 
app.get('/unity', (request,response)=>{
    fs.readFile('./public/Build_file_1/index.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err)
        console.log('Loading page...')
        response.send(html)
    })
})


//VIEWS
app.get('/api/chef', async(request, response)=>{
    
    let connection = null;
    

    try{

        connection = await connectToDB();

        const [results] = await connection.query('select * from SessionChefPreferences')
        //LEADERBOARD DE NIVELES
        //TOP 5 EN RELACIÓN A COMPLETION_RATE
            
            console.log("Sending data correctly.")
            response.status(200)
            response.json(results)
        }

        
    
    catch(error)
    {
        console.log(error)
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        connection.end()
    }
}) 
//ENDPOINT PARA La VIEW DE TOP RANKED
app.get('/api/top', async(request, response)=>{
    
    let connection = null;
    

    try{

        connection = await connectToDB();

        const [results] = await connection.query('select * from TopRankedUsers')
        //LEADERBOARD DE NIVELES
        //TOP 5 EN RELACIÓN A COMPLETION_RATE
            
            console.log("Sending data correctly.")
            response.status(200)
            response.json(results)
        }

        
    
    catch(error)
    {
        console.log(error)
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        connection.end()
    }
}) 

///ENDPOINT PARA LA VIEW DE UserSessionProgress
app.get('/api/sesion_progress', async(request, response)=>{
    
    let connection = null;
    

    try{

        connection = await connectToDB();

        const [results] = await connection.query('select * from UserSessionProgress')
        //LEADERBOARD DE NIVELES
        //TOP 5 EN RELACIÓN A COMPLETION_RATE
            
            console.log("Sending data correctly.")
            response.status(200)
            response.json(results)
        }

        
    
    catch(error)
    {
        console.log(error)
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        connection.end()
    }
}) 

//ENDPOINT PARA VIEW DE MainCharacterDetails
app.get('/api/mainchar', async(request, response)=>{
    
    let connection = null;
    

    try{

        connection = await connectToDB();

        const [results] = await connection.query('select * from MainCharacterDetails')
        //LEADERBOARD DE NIVELES
        //TOP 5 EN RELACIÓN A COMPLETION_RATE
            
            console.log("Sending data correctly.")
            response.status(200)
            response.json(results)
        }

        
    
    catch(error)
    {
        console.log(error)
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        connection.end()
    }
}) 

//ENDPOINTS PARA HACER POSTS EN LAS TABLAS (tipo como el endponit para el login)
// POST PARA PERSON_CHEF
app.post('/api/person_chef', async (request, response)=>{ // se usa post porque se quiere insertar algo

    let connection = null

    try
    {    
        connection = await connectToDB()

        const [results, fields] = await connection.query('insert into Person_Chef set ?', request.body)
        //request.body es un objeto que contiene los datos que se quieren insertar
        
        console.log(`${results.affectedRows} row inserted`)
        response.json({'message': "Data inserted correctly.", "id": results.insertId})// este mensaje se cambia de acuerdo a lo que se haya agregado en la tabla
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
//POST PARA CHECKPOINTS
app.post('/api/checkpoints', async (request, response)=>{ // se usa post porque se quiere insertar algo

    let connection = null

    try
    {    
        connection = await connectToDB()

        const [results, fields] = await connection.query('insert into Checkpoints set ?', request.body)
        //request.body es un objeto que contiene los datos que se quieren insertar
        
        console.log(`${results.affectedRows} row inserted`)
        response.json({'message': "Data inserted correctly.", "id": results.insertId})// este mensaje se cambia de acuerdo a lo que se haya agregado en la tabla
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
//POST PARA SESION
app.post('/api/sesion', async (request, response)=>{ // se usa post porque se quiere insertar algo

    let connection = null

    try
    {    
        connection = await connectToDB()

        const [results, fields] = await connection.query('insert into Sesion set ?', request.body)
        //request.body es un objeto que contiene los datos que se quieren insertar
        
        console.log(`${results.affectedRows} row inserted`)
        response.json({'message': "Data inserted correctly.", "id": results.insertId})// este mensaje se cambia de acuerdo a lo que se haya agregado en la tabla
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
//siempre borrar con where, si no borra toda la tabla
app.listen(port, ()=>
{
    console.log(`App listening at http://localhost:${port}`)
})

// -----------------------------------------------------------------------------------------
// -------------------------------- Unity endpoints ----------------------------------------
// -----------------------------------------------------------------------------------------

app.get('/unity/usuario', async (request, response)=>{ //definir un endpoint
    let connection = null
    //se hace la conexion y un query y después cierra la conexion

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from User')
        //en execute le estamos pidiendo q selecciones toda la tabla de users
        //sigue siendo una promesa entonces usamos await
        //results es un array de objetos, cada objeto es un usuario, viene la info por query
        //fields es un array de objetos, cada objeto es un campo de la tabla
        console.log(`${results.length} rows returned`)//muestra los resultados en consola
        response.json(results)
        //formato json, cuyos atributos serán los nombres de columnas y los valores serán la info de las filas
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally //siempre se ejecuta con o sin error, cierra la conexion
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

app.post('/unity/usuario', async (request, response)=>{ // se usa post porque se quiere insertar algo

    let connection = null

    try
    {    
        connection = await connectToDB()

        const [results, fields] = await connection.query('insert into User set ?', request.body)
        //request.body es un objeto que contiene los datos que se quieren insertar
        
        console.log(`${results.affectedRows} row inserted`)
        response.json({'message': "Data inserted correctly.", "id": results.insertId})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})
app.get('/unity/personalizations', async (request, response)=>{ //definir un endpoint
    let connection = null
    //se hace la conexion y un query y después cierra la conexion

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from Personalization')
        //en execute le estamos pidiendo q selecciones toda la tabla de users
        //sigue siendo una promesa entonces usamos await
        //results es un array de objetos, cada objeto es un usuario, viene la info por query
        //fields es un array de objetos, cada objeto es un campo de la tabla
        console.log(`${results.length} rows returned`)//muestra los resultados en consola
        response.json(results)
        //formato json, cuyos atributos serán los nombres de columnas y los valores serán la info de las filas
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally //siempre se ejecuta con o sin error, cierra la conexion
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

app.post('/unity/personalizations', async (request, response)=>{ // se usa post porque se quiere insertar algo

    let connection = null

    try
    {    
        connection = await connectToDB()

        const [results, fields] = await connection.query('insert into Personalization set ?', request.body)
        //request.body es un objeto que contiene los datos que se quieren insertar
        
        console.log(`${results.affectedRows} row inserted`)
        response.json({'message': "Data inserted correctly.", "id": results.insertId})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

app.get('/unity/sesion', async (request, response)=>{ //definir un endpoint
    let connection = null
    //se hace la conexion y un query y después cierra la conexion

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from Session')
        //en execute le estamos pidiendo q selecciones toda la tabla de users
        //sigue siendo una promesa entonces usamos await
        //results es un array de objetos, cada objeto es un usuario, viene la info por query
        //fields es un array de objetos, cada objeto es un campo de la tabla
        console.log(`${results.length} rows returned`)//muestra los resultados en consola
        response.json(results)
        //formato json, cuyos atributos serán los nombres de columnas y los valores serán la info de las filas
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally //siempre se ejecuta con o sin error, cierra la conexion
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

app.post('/unity/sesion', async (request, response)=>{ // se usa post porque se quiere insertar algo

    let connection = null

    try
    {    
        connection = await connectToDB()

        //const [results, fields] = await connection.query('insert into Sesion (user_id) VALUES (?)', [request.body.user_id]);
        const [results, fields] = await connection.query('insert into Session set ?', request.body)
        //request.body es un objeto que contiene los datos que se quieren insertar
        
        console.log(`${results.affectedRows} row inserted`)
        response.json({'message': "Data inserted correctly.", "id": results.insertId})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

app.get('/unity/skill', async (request, response)=>{ //definir un endpoint
    let connection = null
    //se hace la conexion y un query y después cierra la conexion

    try
    {
        connection = await connectToDB()
        const [results, fields] = await connection.execute('select * from Skilltree')
        //en execute le estamos pidiendo q selecciones toda la tabla de users
        //sigue siendo una promesa entonces usamos await
        //results es un array de objetos, cada objeto es un usuario, viene la info por query
        //fields es un array de objetos, cada objeto es un campo de la tabla
        console.log(`${results.length} rows returned`)//muestra los resultados en consola
        response.json(results)
        //formato json, cuyos atributos serán los nombres de columnas y los valores serán la info de las filas
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally //siempre se ejecuta con o sin error, cierra la conexion
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

app.post('/unity/skill', async (request, response)=>{ // se usa post porque se quiere insertar algo

    let connection = null

    try
    {    
        connection = await connectToDB()

        //const [results, fields] = await connection.query('insert into Sesion (user_id) VALUES (?)', [request.body.user_id]);
        const [results, fields] = await connection.query('insert into Skilltree set ?', request.body)
        //request.body es un objeto que contiene los datos que se quieren insertar
        
        console.log(`${results.affectedRows} row inserted`)
        response.json({'message': "Data inserted correctly.", "id": results.insertId})
    }
    catch(error)
    {
        response.status(500)
        response.json(error)
        console.log(error)
    }
    finally
    {
        if(connection!==null) 
        {
            connection.end()
            console.log("Connection closed succesfully!")
        }
    }
})

