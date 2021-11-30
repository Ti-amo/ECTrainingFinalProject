using EmployeeManagement.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeManagement.DAO {
    public class UserDAO {
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

        public UserDAO() {
            // データベース接続の作成
            connection = new SqlConnection {
                ConnectionString = ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString
            };
            connection.Open();
        }

        /// <summary>
        /// 指定したユーザを抽出する
        /// </summary>
        /// <param name="userId">指定したユーザID</param>
        /// <returns>指定したユーザ</returns>
        public UserEntity Find(string userId) {
            // SQL文：SELECT句
            string query = @"SELECT * 
							FROM m_user 
							WHERE user_id = @user_id";

            // コマンドの作成
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@user_id", userId);

            // データリーダーの作成
            dataReader = command.ExecuteReader();

            UserEntity userEntity = null;
            // データを１行ずつ抽出する
            while (dataReader.Read()) {
                // １ユーザずつ抽出する
                userEntity = new UserEntity {
                    UserId = (string)dataReader["user_id"],
                    Password = (string)dataReader["password"]
                };
            }

            command.Dispose();
            dataReader.Close();

            return userEntity;
        }

        /// <summary>
        /// 指定したユーザを挿入する
        /// </summary>
        /// <param name="userEntity">挿入されたエンティティ</param>
        /// <returns>挿入されたレコード数</returns>
        public int Insert(UserEntity userEntity) {
            // SQL文：INSERT句
            string query = @"INSERT INTO m_user (user_id, password)
							VALUES (@user_id, @password)";

            // トランザクションの作成
            transaction = connection.BeginTransaction();

            // コマンドの作成
            command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@user_id", userEntity.UserId);
            command.Parameters.AddWithValue("@password", userEntity.Password);

            int recordNumber = command.ExecuteNonQuery(); // 挿入されたレコード数
            transaction.Commit();
            transaction.Dispose();
            command.Dispose();

            return recordNumber;
        }
    }
}