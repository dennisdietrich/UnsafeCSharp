using DisposableDemo;

string script = @"
CREATE TABLE db_demo (int_column INTEGER, text_column TEXT);
INSERT INTO db_demo (int_column, text_column) VALUES (47, 'Hello, World!');";

using Database db = new Database("test.db");
db.Execute(script);