## Database Systems - Overview
### _Homework_

#### Answer following questions in Markdown format (`.md` file)

1.  What database models do you know?
    - __- Hierarchical - tree-like structures.__
    - __- A network graph db.__
    - __- Relational table view.__
    - __- Object oriented.__
1.  Which are the main functions performed by a Relational Database Management System (RDBMS)?
    - __- Using SQL to provide easy usage.__
    - __- Cares about stored data - manages all operations over data.__
    - __- MySQL - php.__
    - __- MSSQL Server - .NET.__
    - __- Oracle - Java.__
1.  Define what is "table" in database terms.
    - __- Each table keeps information of objects from one type. Examples: Persons, Cars, Students, 
    Courses. Each table is schema how objects must look like and witch properties must have. Each 
    column is a single property and one row represents one object with this properties aka record.__
    - __Example__:
    pesho | pesho
    ----- | -----
    sad | asd|
1.  Explain the difference between a primary and a foreign key.
    - __- It's highly recommended each table to have a primary key(`PK`). It's a property(column) that
    defines each record will be unique. In most cases DB gives automatically PK value when new record is
    added.__
    - __- Foreign key(`FK`) makes relation between tables. Instead of repeating a whole value form the
    other table, we write only PK from the other table. In our table it's called FK. It's good practice
    PK and FK to have same name in tables.__
1.  Explain the different kinds of relationships between tables in relational databases.
    - __- `One to many` is most often used. One record from first table can exist in many times in 
    second table.__
    - __- `Many to many` between two tables is implemented with third table, where from the left is
    PK from first table and from the right is PK from second table. Now PK for the third table is both
    FK's.__
1.  When is a certain database schema normalized?
    - __- There are several levels of normalization(4). Normalization means that repeatable data must be
    extracted in separate table. Each table must have a PK.__
  * What are the advantages of normalized databases?
        - __- Advantage is that tables are more readable, easy to manage, single responsible principe is
        not violated.__
1.  What are database integrity constraints and when are they used?
    - __- Constraints that define rules how data must be saved. E.g to have a special length, data type
     of property value. Example int, date, varchar, nvarchar(10) etc.__
1.  Point out the pros and cons of using indexes in a database.
    - __- It's difficult to explain, but they are used for fast searching in data bases when there are 
    many records. Some tables stores indexes with reference to other table with indexes and so on. 
    Making a tree-like structure and finally at the bottom is reference to the real table with correct
     record. (something like quick sort algorithm).__
1.  What's the main purpose of the SQL language?
    - __- Operating with DB. Adding, updating, selecting, deleting data with easy human readable queries.
    Or can `create, alter, drop` tables.__
1.  What are transactions used for?
    - __- A sequence of an operations witch manages the query. It's very important operation to be 
    completed in right way - successfully.__
  * Give an example.
        - __- Pessimistic transaction.__
        - __- Pesho and Maria wants to withdraw whole money from one account(imagine that they have rights) 
        in different bank offices. The first one who starts operation must lock the account from other
        interaction. So when the first operation finish start next one. And if Maria is last system must
        inform that there no money in the account.__
1.  What is a NoSQL database?
    - __- Free structure of the document records. It's not necessary each record in the document to have
    same properties. Something like JSON objects. Data is stored as documents. The can't use relations
    (PK/FK).__
1.  Explain the classical non-relational data models.
    - __- I can't. Sorry.__
1.  Give few examples of NoSQL databases and their pros and cons.
    - __- Cassandra - uses for large growing database. Well performance.__
    - __- Redis is used for caching data. key-value model.__
