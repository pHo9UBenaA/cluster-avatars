# stylized-astronaut

## Testing Unity Asset Character to VRM

基本以下に沿ってやる
- https://summer2022.vket.com/docs/submission_tips_vrm_file
- https://vrm.dev/vrm/how_to_make_vrm/convert_from_humanoid_model/

Errorなど
* humanoidにした際にエラー（`Error found while importing rig in this animation file. Open "Import Messages" foldout below for more details`）
Configureを押して、赤くなっている箇所をいい感じに調整

* アップロード時にボーンが足りないむねのエラーが発生
Neckがそもそも標準で含まれていなかったので、Blenderで追加した
https://yamato.studio/blog/4734