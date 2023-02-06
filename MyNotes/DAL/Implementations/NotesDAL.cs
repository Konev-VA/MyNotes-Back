using Dapper;
using MyNotes.DAL.Interfaces;
using MyNotes.DAL.Models;
using MyNotes.Models;
using Npgsql;
using System.Data;

namespace MyNotes.DAL.Implementations
{
    public class NotesDAL : INotesDAL
    {
        string _connectionString;
        public NotesDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Note>> GetNotes()
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string commandText = $@"SELECT noteId as {nameof(Note.Id)},
                                               title as {nameof(Note.Title)},
                                               text as {nameof(Note.Text)},
                                               authorid as {nameof(Note.AuthorID)} 
                                               FROM Notes";

                return await db.QueryAsync<Note>(commandText);
            }
        }

        public async Task<Note> GetNoteById(int id)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                string commandText = @$"SELECT noteId as {nameof(Note.Id)},
                                               title as {nameof(Note.Title)},
                                               text as {nameof(Note.Text)},
                                               authorid as {nameof(Note.AuthorID)} 
                                               FROM Notes
                                               WHERE noteId = @id";

                return await db.QueryFirstOrDefaultAsync<Note>(commandText, new { id = id });
            }
        }

        public async Task<int> Add(Note note)
        {
            using (IDbConnection db = new NpgsqlConnection(_connectionString))
            {
                db.Open();
                string commandText = $@"INSERT INTO public.notes
                                        (title, ""text"", authorid)
                                        VALUES(@Title, @Text, @AuthorID);
                                        SELECT currval(pg_get_serial_sequence('notes','noteid'));";


                var temp = await db.QueryFirstOrDefaultAsync<int>(commandText, new { Title = note.Title, Text = note.Text, AuthorID = note.AuthorID });

                return temp;
            }
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(int id, Note note)
        {
            throw new NotImplementedException();
        }
    }
}
