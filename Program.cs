using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


namespace ConsoleApp12
{
	internal class Program
	{
		// 定義基礎 URL
		private static readonly string BaseUrl = "https://pokeapi.co/api/v2/item/";
		// 初始化 HttpClient 以進行 HTTP 請求。
		private static HttpClient httpClient = new HttpClient();

		public static async Task Main(string[] args)
		{
			// 目標 1
			var totalItemCount = await FetchTotalItemCount();
			Console.WriteLine($"物品總數量: {totalItemCount}");

			// 目標 2
			var itemsUnder20 = await FetchItemsInRange(1, 19);
			Console.WriteLine("\nID < 20 的寶可夢物品名稱：");
			foreach (var item in itemsUnder20)
			{
				Console.WriteLine(item.ㄐㄟname);
			}

			// 目標 3
			var itemsUnder50WithCost = await FetchItemsWithCostCondition(1, 49, 1500);
			Console.WriteLine("\nID < 50, ID> 0 ，價格 <= 1500 的寶可夢物品名稱及價格，價格由大至小排序排序：");
			foreach (var item in itemsUnder50WithCost.OrderByDescending(i => i.cost))
			{
				Console.WriteLine($"{item.name} - 價格：{item.cost}");
			}
		}

		private static async Task<int> FetchTotalItemCount()
		{
			var response = await httpClient.GetStringAsync(BaseUrl);
			// 將回應的 JSON 字串反序列化為 ItemsList 類別的實例。
			var itemsList = JsonSerializer.Deserialize<ItemsList>(response);
			return itemsList.count;
		}

		private static async Task<List<Item>> FetchItemsInRange(int startId, int endId)
		{
			var tasks = Enumerable.Range(startId, endId - startId + 1).Select(FetchItemById).ToList();
			return (await Task.WhenAll(tasks)).ToList();
		}

		private static async Task<Item> FetchItemById(int id)
		{
			// 創建一個任務列表，用於非同步獲取每個 ID 對應的物品。
			var response = await httpClient.GetStringAsync(BaseUrl + id);
			//將結果轉換為一個列表
			return JsonSerializer.Deserialize<Item>(response);
		}

		private static async Task<List<Item>> FetchItemsWithCostCondition(int startId, int endId, int maxCost)
		{
			// 首先獲取指定範圍內的所有物品。
			var allItems = await FetchItemsInRange(startId, endId);
			// 然後根據最大花費進行篩選。
			return allItems.Where(i => i.cost <= maxCost).ToList();
		}

		public class ItemsList
		{
			public int count { get; set; }
			public List<ItemReference> results { get; set; }
		}

		public class ItemReference
		{
			public string name { get; set; }
			public string url { get; set; }
		}

		public class Item
		{
			public string name { get; set; }
			public int cost { get; set; }
		}
	}
}
	
