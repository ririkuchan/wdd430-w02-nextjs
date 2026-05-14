using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalesReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // 課題用のテストデータ（合計金額と内訳）
            double totalSales = 2500.50;
            var details = new List<(string fileName, double fileTotal)>
            {
                ("sales.json", 1000.25),
                ("2023.json", 1500.25)
            };

            // レポート生成関数の実行
            GenerateSalesSummary(totalSales, details);

            Console.WriteLine("レポート作成完了: salesSummary.txt を確認してください。");
        }

        // ★追加課題のメイン機能：レポートを生成してファイルに保存する関数
        static void GenerateSalesSummary(double totalSales, IEnumerable<(string fileName, double fileTotal)> details)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Sales Summary");
            sb.AppendLine("----------------------------");
            // 通貨形式（$）でフォーマット
            sb.AppendLine($" Total Sales: {totalSales:C}");
            sb.AppendLine("");
            sb.AppendLine(" Details:");

            foreach (var item in details)
            {
                sb.AppendLine($"  {item.fileName}: {item.fileTotal:C}");
            }

            // テキストファイルとして書き出し
            File.WriteAllText("salesSummary.txt", sb.ToString());
        }
    }
}