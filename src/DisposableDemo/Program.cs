using System.Runtime.CompilerServices;
using DisposableDemo;
using System.Runtime.InteropServices;
using System.Text;

string script = @"
CREATE TABLE db_demo (int_column INTEGER, text_column TEXT);
INSERT INTO db_demo (int_column, text_column) VALUES (47, 'Hello, World!');
INSERT INTO db_demo (int_column, text_column) VALUES (23, 'Hello, SQLite!');";

using Database db = new Database("test.db");
db.Execute(script);

unsafe
{
    db.Execute("SELECT int_column, text_column FROM db_demo;", (_, columns, values, names) =>
    {
        try
        {
            for (int i = 0; i < columns;)
            {
                Console.Write($"{FromUtf8(names[i])}: {FromUtf8(values[i])}");
                Console.Write(++i == columns ? Environment.NewLine : ", ");
            }

            return ResultCode.Ok;
        }
        catch
        {
            return ResultCode.Error;
        }
    });
}

unsafe
{
    db.Execute("SELECT int_column, text_column FROM db_demo;", &PrintRow);
}

[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
static unsafe ResultCode PrintRow(void* ptr, int columns, byte** values, byte** names)
{
    try
    {
        for (int i = 0; i < columns;)
        {
            Console.Write($"{FromUtf8(names[i])}: {FromUtf8(values[i])}");
            Console.Write(++i == columns ? Environment.NewLine : ", ");
        }

        return ResultCode.Ok;
    }
    catch
    {
        return ResultCode.Error;
    }
}

static unsafe string FromUtf8(byte* pStr)
{
    int length = 0;

    while (*(pStr + length) != 0)
        length++;

    byte[] copy = new byte[length];
    Marshal.Copy((IntPtr)pStr, copy, 0, length);
    return Encoding.UTF8.GetString(copy);
}