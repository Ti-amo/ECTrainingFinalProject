using EmployeeManagement.Item;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeManagement.DAO {
    public class ListDAO {
        /// <summary>
        /// データベースとのコネクション
        /// </summary>
        private readonly SqlConnection connection;
        /// <summary>
        /// コマンド
        /// </summary>
        private SqlCommand command;
        /// <summary>
        /// データリーダー
        /// </summary>
        private SqlDataReader dataReader;

        public ListDAO() {
            // データベース接続の作成
            connection = new SqlConnection {
                ConnectionString = ConfigurationManager.ConnectionStrings["employeedb"].ConnectionString
            };
            connection.Open();
        }

        /// <summary>
        /// すべての性別を抽出する
        /// </summary>
        /// <returns>性別のリスト</returns>
        public List<GenderItem> GetGenderList() {
            // SQL文：SELECT句
            string query = @"SELECT * 
							FROM m_gender";

            // コマンドの作成
            command = new SqlCommand(query, connection);

            // データリーダーの作成
            dataReader = command.ExecuteReader();

            List<GenderItem> genderList = new List<GenderItem>();
            // データを１行ずつ抽出する
            while (dataReader.Read()) {
                GenderItem genderItem = new GenderItem {
                    GenderCode = (int)dataReader["gender_cd"],
                    GenderName = (string)dataReader["gender_nm"]
                };

                genderList.Add(genderItem);
            }

            command.Dispose();
            dataReader.Close();

            return genderList;
        }

        /// <summary>
        /// すべての所属を抽出する
        /// </summary>
        /// <returns>所属のリスト</returns>
        public List<SectionItem> GetSectionList() {
            // SQL文：SELECT句
            string query = @"SELECT * 
							FROM m_section";

            // コマンドの作成
            command = new SqlCommand(query, connection);

            // データリーダーの作成
            dataReader = command.ExecuteReader();

            List<SectionItem> sectionList = new List<SectionItem>();
            // データを１行ずつ抽出する
            while (dataReader.Read()) {
                SectionItem sectionItem = new SectionItem {
                    SectionCode = (string)dataReader["section_cd"],
                    SectionName = (string)dataReader["section_nm"]
                };

                sectionList.Add(sectionItem);
            }

            command.Dispose();
            dataReader.Close();

            return sectionList;
        }

        /// <summary>
        /// すべての資格を抽出する
        /// </summary>
        /// <returns>資格のリスト</returns>
        public List<LicenseItem> GetLicenseList() {
            // SQL文：SELECT句
            string query = @"SELECT * 
							FROM m_license";

            // コマンドの作成
            command = new SqlCommand(query, connection);

            // データリーダーの作成
            dataReader = command.ExecuteReader();

            List<LicenseItem> licenseList = new List<LicenseItem>();
            // データを１行ずつ抽出する
            while (dataReader.Read()) {
                LicenseItem licenseItem = new LicenseItem {
                    LicenseCode = (string)dataReader["license_cd"],
                    LicenseName = (string)dataReader["license_nm"]
                };

                licenseList.Add(licenseItem);
            }

            command.Dispose();
            dataReader.Close();

            return licenseList;
        }
    }
}