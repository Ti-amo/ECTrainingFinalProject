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
                            FROM m_employee e
                            INNER JOIN m_gender g ON g.gender_cd = e.gender_cd 
                            INNER JOIN m_section s ON s.section_cd = e.section_cd";

            // コマンドの作成
            command = new SqlCommand(query, connection);
            // データリーダーの作成
            dataReader = command.ExecuteReader();

            LicenseDAO licenseDAO = new LicenseDAO();

            // データを１行ずつ抽出する
            while (dataReader.Read()) {
                // １従業員ずつ抽出する
                EmployeeEntity employeeEntity = new EmployeeEntity {
                    EmpCode = (string)dataReader["emp_cd"],
                    Name = (string)dataReader["name"],
                    NameKana = (string)dataReader["name_kana"],
                    Gender = (string)dataReader["gender_nm"],
                    BirthDate = Convert.ToDateTime(dataReader["birth_date"]).ToString("yyyy/MM/dd"),
                    Section = (string)dataReader["section_nm"],
                    EmpDate = Convert.ToDateTime(dataReader["emp_date"]).ToString("yyyy/MM/dd")
                };
                employeeEntity.License = licenseDAO.FindAll(employeeEntity.EmpCode);

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
                            FROM m_employee e
                            INNER JOIN m_gender g ON g.gender_cd = e.gender_cd 
                            INNER JOIN m_section s ON s.section_cd = e.section_cd 
							WHERE emp_cd = @emp_cd";

            // コマンドの作成
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@emp_cd", empCode);

            // データリーダーの作成
            dataReader = command.ExecuteReader();

            LicenseDAO licenseDAO = new LicenseDAO();

            EmployeeEntity employeeEntity = null;
            // データを１行ずつ抽出する
            while (dataReader.Read()) {
                // １従業員ずつ抽出する
                employeeEntity = new EmployeeEntity {
                    EmpCode = (string)dataReader["emp_cd"],
                    Name = (string)dataReader["name"],
                    NameKana = (string)dataReader["name_kana"],
                    Gender = (string)dataReader["gender_nm"],
                    BirthDate = Convert.ToDateTime(dataReader["birth_date"]).ToString("yyyy/MM/dd"),
                    Section = (string)dataReader["section_nm"],
                    EmpDate = Convert.ToDateTime(dataReader["emp_date"]).ToString("yyyy/MM/dd")
                };
                employeeEntity.License = licenseDAO.FindAll(employeeEntity.EmpCode);
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
							VALUES (@emp_cd, @name, @name_kana, @gender_cd, CAST(@birth_date AS Date), @section_cd, CAST(@emp_date AS Date))";

            // トランザクションの作成
            transaction = connection.BeginTransaction();

            // コマンドの作成
            command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@emp_cd", employeeEntity.EmpCode);
            command.Parameters.AddWithValue("@name", employeeEntity.Name);
            command.Parameters.AddWithValue("@name_kana", employeeEntity.NameKana);
            command.Parameters.AddWithValue("@gender_cd", employeeEntity.Gender);
            command.Parameters.AddWithValue("@section_cd", employeeEntity.Section);
            //DateTime date = DateTime.ParseExact(employeeEntity.BirthDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime birthDate = Convert.ToDateTime(employeeEntity.BirthDate);
            command.Parameters.AddWithValue("@birth_date", birthDate);
            //DateTime empDate = DateTime.ParseExact(employeeEntity.EmpDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime empDate = Convert.ToDateTime(employeeEntity.EmpDate);

            command.Parameters.AddWithValue("@emp_date", empDate);
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
							SET name = @name, name_kana = @name_kana, gender_cd = @gender_cd, birth_date = CAST(@birth_date AS Date), section_cd = @section_cd, emp_date = CAST(@emp_date AS Date) 
							WHERE emp_cd = @emp_cd";

            // トランザクションの作成
            transaction = connection.BeginTransaction();

            // コマンドの作成
            command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@emp_cd", employeeEntity.EmpCode);
            command.Parameters.AddWithValue("@name", employeeEntity.Name);
            command.Parameters.AddWithValue("@name_kana", employeeEntity.NameKana);
            command.Parameters.AddWithValue("@gender_cd", employeeEntity.Gender);
            command.Parameters.AddWithValue("@birth_date", employeeEntity.BirthDate);
            command.Parameters.AddWithValue("@section_cd", employeeEntity.Section);
            command.Parameters.AddWithValue("@emp_date", employeeEntity.EmpDate);

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