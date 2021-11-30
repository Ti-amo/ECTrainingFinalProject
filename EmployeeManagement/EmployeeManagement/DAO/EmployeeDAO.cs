using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using EmployeeManagement.Entity;

namespace EmployeeManagement.DAO {
    public class EmployeeDAO {
        /// <summary>
        /// データベースとのコネクション
        /// </summary>
        private readonly SqlConnection connection;
        /// <summary>
        /// コネクションに関連するトランザクション
        /// </summary>
        private SqlTransaction transaction;
        /// <summary>
        /// コマンド
        /// </summary>
        private SqlCommand command;
        /// <summary>
        /// データリーダー
        /// </summary>
        private SqlDataReader dataReader;

        public EmployeeDAO() {
            // データベース接続の作成
            connection = new SqlConnection {
                ConnectionString = ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString
            };
            connection.Open();
        }

        /// <summary>
        /// すべての従業員を抽出する
        /// </summary>
        /// <returns>すべての従業員</returns>
        public List<EmployeeEntity> FindAll() {
            // すべての従業員のリスト
            List<EmployeeEntity> employeeList = new List<EmployeeEntity>();

            // SQL文：SELECT句
            string query = @"SELECT * 
							FROM m_employee";

            // コマンドの作成
            command = new SqlCommand(query, connection);
            // データリーダーの作成
            dataReader = command.ExecuteReader();

            // データを１行ずつ抽出する
            while (dataReader.Read()) {
                // １従業員ずつ抽出する
                EmployeeEntity employeeEntity = new EmployeeEntity {
                    EmpCode = (string)dataReader["emp_cd"],
                    Name = (string)dataReader["name"],
                    NameKana = (string)dataReader["name_kana"],
                    Gender = (int)dataReader["gender_cd"],
                    BirthDate = (string)dataReader["birth_date"],
                    Section = (string)dataReader["section_cd"],
                    EmpDate = (string)dataReader["emp_date"]
                };

                // 従業員をリストに格納する
                employeeList.Add(employeeEntity);
            }

            command.Dispose();
            dataReader.Close();

            return employeeList;
        }

        /// <summary>
        /// 指定した従業員を抽出する
        /// </summary>
        /// <param name="empCode">指定した従業員コード</param>
        /// <returns>指定した従業員</returns>
        public EmployeeEntity Find(string empCode) {
            // SQL文：SELECT句
            string query = @"SELECT * 
							FROM m_employee 
							WHERE emp_cd = @emp_cd";

            // コマンドの作成
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@emp_cd", empCode);

            // データリーダーの作成
            dataReader = command.ExecuteReader();

            EmployeeEntity employeeEntity = null;
            // データを１行ずつ抽出する
            while (dataReader.Read()) {
                // １従業員ずつ抽出する
                employeeEntity = new EmployeeEntity {
                    EmpCode = (string)dataReader["emp_cd"],
                    Name = (string)dataReader["name"],
                    NameKana = (string)dataReader["name_kana"],
                    Gender = (int)dataReader["gender_cd"],
                    BirthDate = (string)dataReader["birth_date"],
                    Section = (string)dataReader["section_cd"],
                    EmpDate = (string)dataReader["emp_date"]
                };
            }

            command.Dispose();
            dataReader.Close();

            return employeeEntity;
        }

        /// <summary>
        /// 指定した従業員を挿入する
        /// </summary>
        /// <param name="employeeEntity">挿入されたエンティティ</param>
        /// <returns>挿入されたレコード数</returns>
        public int Insert(EmployeeEntity employeeEntity) {
            // SQL文：INSERT句
            string query = @"INSERT INTO m_employee (emp_cd, name, name_kana, gender_cd, birth_date, section_cd, emp_date)
							VALUES (@emp_cd, @name, @name_kana, @gender_cd, @birth_date, @section_cd, @emp_date)";

            // トランザクションの作成
            transaction = connection.BeginTransaction();

            // コマンドの作成
            command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@emp_cd", employeeEntity.EmpCode);
            command.Parameters.AddWithValue("@name", employeeEntity.Name);
            command.Parameters.AddWithValue("@name_kana", employeeEntity.NameKana);
            command.Parameters.AddWithValue("@gender_cd", employeeEntity.Gender);
            command.Parameters.AddWithValue("@section_cd", employeeEntity.Section);

            DateTime date = DateTime.ParseExact(employeeEntity.BirthDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            command.Parameters.AddWithValue("@birth_date", date);
            date = DateTime.ParseExact(employeeEntity.EmpDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            command.Parameters.AddWithValue("@emp_date", date);

            int recordNumber = command.ExecuteNonQuery(); // 挿入されたレコード数
            transaction.Commit();
            transaction.Dispose();
            command.Dispose();

            return recordNumber;
        }

        /// <summary>
        /// 指定した従業員を更新する
        /// </summary>
        /// <param name="employeeEntity">更新されたエンティティ</param>
        /// <returns>更新されたレコード数</returns>
        public int Update(EmployeeEntity employeeEntity) {
            // SQL文：UPDATE句
            string query = @"UPDATE m_employee 
							SET name = @name, name_kana = @name_kana, gender_cd = @gender_cd, birth_date = @birth_date, section_cd = @section_cd, emp_date = @emp_date 
							WHERE emp_cd = @emp_cd";

            // トランザクションの作成
            transaction = connection.BeginTransaction();

            // コマンドの作成
            command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@emp_cd", employeeEntity.EmpCode);
            command.Parameters.AddWithValue("@name", employeeEntity.Name);
            command.Parameters.AddWithValue("@name_kana", employeeEntity.NameKana);
            command.Parameters.AddWithValue("@gender_cd", employeeEntity.Gender);
            command.Parameters.AddWithValue("@section_cd", employeeEntity.Section);

            DateTime date = DateTime.ParseExact(employeeEntity.BirthDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            command.Parameters.AddWithValue("@birth_date", date);
            date = DateTime.ParseExact(employeeEntity.EmpDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            command.Parameters.AddWithValue("@emp_date", date);

            int recordNumber = command.ExecuteNonQuery(); // 更新されたレコード数
            transaction.Commit();
            transaction.Dispose();
            command.Dispose();

            return recordNumber;
        }

        /// <summary>
        /// 指定した従業員を削除する
        /// </summary>
        /// <param name="employeeEntity">削除されたエンティティ</param>
        /// <returns>削除されたレコード数</returns>
        public int Delete(EmployeeEntity employeeEntity) {
            // SQL文：DELETE句
            string query = @"DELETE FROM m_employee 
							WHERE emp_cd = @emp_cd";

            // トランザクションの作成
            transaction = connection.BeginTransaction();

            // コマンドの作成
            command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@emp_cd", employeeEntity.EmpCode);

            int recordNumber = command.ExecuteNonQuery(); // 削除されたレコード数
            transaction.Commit();
            transaction.Dispose();
            command.Dispose();

            return recordNumber;
        }
    }
}