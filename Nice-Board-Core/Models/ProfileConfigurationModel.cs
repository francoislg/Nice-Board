namespace Nice_Board.Core.Models
{
    public struct ProfileConfigurationModel
    {
        public string Name { get; set; }
        public GoogleConfigurationModel? Google { get; set; }
    }
}
