# 选项卡开发概要
> 陈希章 2018-11-18

请按照如下的步骤进行实践
1. 确保安装开发环境（NodeJS，VSCode）
1. 安装必要的模块 npm i -g yo generator-teams
1. 使用yo teams生成项目，注意选择Tab即可
1. 运行 gulp build ，确保没有错误
1. 按照项目文件夹中的说明，部署到Azure，或者使用 [ngrok](https://ngrok.com/) 这个工具在本地实现一个地址转发，需要得到一个https的地址。
1. 如果你是用ngrok转发，则需要修改项目文件夹中的 src/manifest.json 文件，修改 configurationUrl 这个属性为你实际看到ngrok生成的https地址。
1. 运行 gulp manifest，生成一个zip文件
1. 将这个zip文件上传到Teams中，在某给具体的Team中测试Tab的功能。
