using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using EmployeeManagement.Entity;

namespace EmployeeManagement.DAO {
    public class LicenseDAO {
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

        public LicenseDAO() {
            // データベース接続の作成
            connection = new SqlConnection {
                ConnectionString = ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString
            };
            connection.Open();
        }

        /// <summary>
        /// 指定された従業員のすべての資格を抽出する
        /// </summary>
        /// <param name="empCode">指定した従業員コード</param>
        /// <returns>資格のリスト</returns>
        public List<string> FindAll(string empCode) {
            // SQL文：SELECT句
            string query = @"SELECT * 
							FROM t_get_license gl 
                            LEFT JOIN m_license l ON l.license_cd = gl.license_cd 
							WHERE emp_cd = @emp_cd";

            // コマンドの作成
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@emp_cd", empCode);

            // データリーダーの作成
            dataReader = command.ExecuteReader();

            List<string> licenseList = new List<string>();
            // データを１行ずつ抽出する
            while (dataReader.Read()) {
                // １資格ずつ抽出する
                string license = (string)dataReader["license_nm"];
                licenseList.Add(license);
            }

            command.Dispose();
            dataReader.Close();

            return licenseList;
        }

        /// <summary>
        /// 指定した資格保有従業員を挿入する
        /// </summary>
        /// <param name="licenseEntity">挿入されたエンティティ</param>
        /// <returns>挿入されたレコード数</returns>
        public int Insert(LicenseEntity licenseEntity) {
            // SQL文：INSERT句
            string query = @"INSERT INTO t_get_license (emp_cd, license_cd, get_license_date)
							VALUES (@emp_cd, @license_cd, CAST(@get_license_date AS Date))";

            // トランザクションの作成
            transaction = connection.BeginTransaction();

            // コマンドの作成
            command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@emp_cd", licenseEntity.EmpCode);
            command.Parameters.AddWithValue("@license_cd", licenseEntity.LicenseCode);
            command.Parameters.AddWithValue("@get_license_date", licenseEntity.GetLicenseDate);

            int recordNumber = command.ExecuteNonQuery(); // 挿入されたレコード数
            transaction.Commit();
            transaction.Dispose();
            command.Dispose();

            return recordNumber;
        }

        /// <summary>
        /// 指定した資格取得を抽出する
        /// </summary>
        /// <param name="empCode">従業員コード</param>
        /// <param name="licenseCode">資格コード</param>
        /// <returns>指定した資格取得</returns>
        public LicenseEntity Find(string empCode, string licenseCode) {
            // SQL文：SELECT句
            string query = @"SELECT * 
                            FROM t_get_license 
                            WHERE (emp_cd = @emp_cd AND license_cd = @license_cd)";

            // コマンドの作成
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@emp_cd", empCode);
            command.Parameters.AddWithValue("@license_cd", licenseCode);

            // データリーダーの作成
            dataReader = command.ExecuteReader();

            LicenseEntity licenseEntity = null;
            // データを１行ずつ抽出する
            while (dataReader.Read()) {
                licenseEntity = new LicenseEntity {
                    EmpCode = (string)dataReader["emp_cd"],
                    LicenseCode = (string)dataReader["license_cd"],
                    GetLicenseDate = Convert.ToDateTime(dataReader["get_license_date"]).ToString("yyyy-MM-dd")
                };
            }

            command.Dispose();
            dataReader.Close();

            return licenseEntity;
        }
    }
}