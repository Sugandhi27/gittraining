using System;
using System.Data;
using System.Data.SqlClient;

namespace ADOExampleProject
{
    class Program
    {
        string conString;
        SqlConnection con;
        SqlCommand cmd;
        public Program()
        {
            conString = @"server=LAPTOP-I3KLNJOV\SQLEXPRESS;Integrated security=true;Initial catalog=pubs";
            con = new SqlConnection(conString);
        }
        void FetchMoviesFromDatabase()
        {
            string strCmd = "Select * from tblMovie";
            cmd = new SqlCommand(strCmd, con);
            try
            {
                con.Open();
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("Movie Id:" + drMovies[0].ToString());
                    Console.WriteLine("Movie Name:" + drMovies[1]);
                    Console.WriteLine("Movie Duration:" + drMovies[2].ToString());
                    Console.WriteLine("---------------------");

                }
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException.Message);
            }
            finally
            {
                con.Close();
            }
        }
            void FetchOneMovieFromDatabase()
            {
                string strCmd = "Select * from tblMovie where id=@mid";
                cmd = new SqlCommand(strCmd, con);
                try
                {
                    con.Open();

                    Console.WriteLine("Please enter the Movie Id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    cmd.Parameters.Add("@mid", SqlDbType.Int);
                    cmd.Parameters[0].Value = id;
                    SqlDataReader drMovies = cmd.ExecuteReader();
                    while (drMovies.Read())
                    {
                        Console.WriteLine("Movie Id : " + drMovies[0]);
                        Console.WriteLine("Movie Name : " + drMovies[1]);
                        Console.WriteLine("Movie Duration : " + drMovies[2].ToString());

                        Console.WriteLine("-----------------------------------");

                    }
                }
                catch (SqlException sqlExecution)
                {
                    Console.WriteLine(sqlExecution.Message);
                }
                finally
                {
                    con.Close();
                }
            }


            void UpdateMovieDuration()

            {
                Console.WriteLine("Please enter the movie id : ");
                string id = Console.ReadLine();
                Console.WriteLine("Please enter the movie duration : ");
                float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()), 2);
                string strCmd = "Update tblMovie set duration = @mduration where id = @mid";
                cmd = new SqlCommand(strCmd, con);
                cmd.Parameters.AddWithValue("@mid", id);
                cmd.Parameters.AddWithValue("@mduration", mDuration);

                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        Console.WriteLine("Movie updated");
                    else
                        Console.WriteLine("Task not done");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            void AddMovie()
            {
                Console.WriteLine("Please enter the movie name");
                string mName = Console.ReadLine();
                Console.WriteLine("Enter duration");
                float mDuration = (float)Math.Round(float.Parse(Console.ReadLine()), 2);
                string strCmd = "Update tblMovie set duration = @mduration where id = @mid";
                cmd = new SqlCommand(strCmd, con);
                cmd.Parameters.AddWithValue("@mname", mName);
                cmd.Parameters.AddWithValue("@mdur", mDuration);
                try
                {
                    con.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                        Console.WriteLine("Movie inserted");
                    else
                        Console.WriteLine("no no...");
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                finally
                {
                    con.Close();
                }
            }
                void DeleteMovie()
                {
                    Console.WriteLine("Please enter the Id");
                    int id = Convert.ToInt32(Console.ReadLine());
                    string strCmd = "delete from tblMovie where id=@mid";
                    cmd = new SqlCommand(strCmd, con);
                    cmd.Parameters.AddWithValue("@mid", id);
                    try
                    {
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                            Console.WriteLine("Movie deleted");
                        else
                            Console.WriteLine("No not done");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add a movie");
                Console.WriteLine("2. Fetch one movie");
                Console.WriteLine("3. Fetch all movies");
                Console.WriteLine("4. Update the movie duration");
                Console.WriteLine("5. Delete a movie");
                Console.WriteLine("-------------------------------");

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddMovie();
                        break;
                    case 2:
                        FetchOneMovieFromDatabase();
                        break;
                    case 3:
                        FetchMoviesFromDatabase();
                        break;
                    case 4:
                        UpdateMovieDuration();
                        break;
                    case 5:
                        DeleteMovie();
                        break;

                    default:
                        Console.WriteLine("Invalid entry made");
                        break;

                }
            } while (choice != 6);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program program = new Program();
            //program.AddMovie();
            //program.FetchMoviesFromDatabase();
            program.UpdateMovieDuration();
            program.FetchOneMovieFromDatabase();
            Console.ReadKey();
        }
    }
}
